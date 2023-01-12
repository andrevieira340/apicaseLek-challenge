using CaseLEKSTIASPNETMVCSimplificado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Repositories
{
    public interface IMovimentationRepository
    {
        Task<IEnumerable<Movimentations>> GetAllMovimentations();
        Task<Movimentations> Get(int id);
        Task<Movimentations> CreateEntryOrExit(Movimentations entryOrExit);
        Task Update(Movimentations movimentations);
        Task Delete(int id);
        

    }
}
