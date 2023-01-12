using CaseLEKSTIASPNETMVCSimplificado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Repositories
{
    public interface ICommodityRepository
    {
        Task<IEnumerable<Commodity>> Get();
        Task<Commodity> Get(int id);
        Task<Commodity> Create(Commodity commodity);
        Task Update(Commodity commodity);
        Task Delete(int id);
    }
}
