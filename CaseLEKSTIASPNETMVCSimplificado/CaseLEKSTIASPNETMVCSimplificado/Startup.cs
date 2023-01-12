using CaseLEKSTIASPNETMVCSimplificado.Context;
using CaseLEKSTIASPNETMVCSimplificado.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IMovimentationRepository, MovimentationRepository>();
           // services.AddTransient<ICommodityRepository, CommodityRepository>();
            //services.AddSingleton<IMovimentationRepository, MovimentationRepository>();
           // services.AddSingleton<ICommodityRepository, CommodityRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<IMovimentationRepository, MovimentationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CaseLEKSTIASPNETMVCSimplificado", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ServerConnection")), ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaseLEKSTIASPNETMVCSimplificado v1"));
            }

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
