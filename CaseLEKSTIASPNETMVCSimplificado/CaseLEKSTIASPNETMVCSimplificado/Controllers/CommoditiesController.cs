using CaseLEKSTIASPNETMVCSimplificado.Context;
using CaseLEKSTIASPNETMVCSimplificado.Models;
using CaseLEKSTIASPNETMVCSimplificado.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CaseLEKSTIASPNETMVCSimplificado.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CommoditiesController : ControllerBase
    {
        public readonly ICommodityRepository _repository;
        public CommoditiesController (ICommodityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Commodity>> GetCommodities()
        {
            var getAllCommodities = await _repository.Get();
            return Ok(getAllCommodities);
        }
        [HttpPost]
        public async Task<ActionResult<Commodity>> PostCommodity([FromBody] Commodity commodity)
        {
            var newCommodity = await _repository.Create(commodity);
            
            return CreatedAtAction(nameof(GetCommodities), new { id = newCommodity.Id }, newCommodity);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Commodity>> GetCommodityById(int id)
        {
            return await _repository.Get(id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commodity>> DeleteCommodity(int id)
        {
            var getCommodity = await _repository.Get(id);
            if (getCommodity == null)
            {
                return NotFound();
            }
            await _repository.Delete(getCommodity.Id);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutCommodity(int id, [FromBody] Commodity commodity)
        {
            if (id != commodity.Id)
                return BadRequest();

            await _repository.Update(commodity);

            return NoContent();
        }
        //----------get movimentations--------------//
       

    }
}
