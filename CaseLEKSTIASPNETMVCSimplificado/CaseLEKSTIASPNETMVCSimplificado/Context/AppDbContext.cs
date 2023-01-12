using CaseLEKSTIASPNETMVCSimplificado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Movimentations> Movimentations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", false, true)
                 .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
