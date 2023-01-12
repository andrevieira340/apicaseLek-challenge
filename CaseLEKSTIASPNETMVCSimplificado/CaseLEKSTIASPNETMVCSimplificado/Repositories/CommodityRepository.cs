using CaseLEKSTIASPNETMVCSimplificado.Context;
using CaseLEKSTIASPNETMVCSimplificado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Repositories
{
    public class CommodityRepository : ICommodityRepository
    {
        public readonly AppDbContext _context;

        public CommodityRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Commodity> Create(Commodity commodity)
        {

            _context.Commodities.Add(commodity);
            await _context.SaveChangesAsync();
            return commodity;
        }

        public async Task Delete(int id)
        {
            var commodityToDelete = await _context.Commodities.FindAsync(id);
            _context.Commodities.Remove(commodityToDelete);
      
        }

        public async Task<IEnumerable<Commodity>> Get()
        {
            return await _context.Commodities.ToListAsync();
        }

        public async Task<Commodity> Get(int id)
        {
            return await _context.Commodities.FindAsync(id);
        }

        public async Task Update(Commodity commodity)
        {
            _context.Entry(commodity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
