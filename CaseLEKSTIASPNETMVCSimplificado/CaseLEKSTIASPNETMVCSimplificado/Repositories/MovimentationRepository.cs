using CaseLEKSTIASPNETMVCSimplificado.Context;
using CaseLEKSTIASPNETMVCSimplificado.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Repositories
{
    public class MovimentationRepository : IMovimentationRepository
    {
        public readonly AppDbContext _context;


        public MovimentationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movimentations> CreateEntryOrExit(Movimentations entryOrExit)
        {
            _context.Movimentations.Add(entryOrExit);
            await _context.SaveChangesAsync();
            return entryOrExit;
        }

        public async Task Delete(int id)
        {

            var item = await _context.Movimentations.FindAsync(id);
            _context.Movimentations.Attach(item);
           _context.Movimentations.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Movimentations> Get(int id)
        {
            return await _context.Movimentations.FindAsync(id);
        }

        public async Task<IEnumerable<Movimentations>> GetAllMovimentations()
        {

            return await _context.Movimentations.ToListAsync();
        }
        public async Task Update(Movimentations movimentations)
        {
            _context.Entry(movimentations).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
