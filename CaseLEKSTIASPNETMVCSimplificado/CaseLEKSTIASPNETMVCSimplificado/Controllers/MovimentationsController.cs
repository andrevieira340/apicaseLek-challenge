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
    public class MovimentationsController : ControllerBase
    {
        public readonly IMovimentationRepository _movimentationRepository;
        public  IUnitOfWork uow;
        public MovimentationsController( IMovimentationRepository movimentationRepository, IUnitOfWork _uow)
        {
            _movimentationRepository = movimentationRepository;
            uow = _uow;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutMovimentations(int id, [FromBody] Movimentations movimentations)
        {
            if (id != movimentations.Id)
            {
                return BadRequest();
            }
            await _movimentationRepository.Update(movimentations);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimentations>> GetMovimentationsById(int id)
        {
            return await _movimentationRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Movimentations>> AddMovimentation([FromBody] Movimentations entryOrExit)
        {

            var newEntryOrExit = await _movimentationRepository.CreateEntryOrExit(entryOrExit);
            return CreatedAtAction(nameof(GetEntriesAndExits), new { id = newEntryOrExit.Id }, newEntryOrExit);
        }

        [HttpGet]
        public async Task<ActionResult> GetEntriesAndExits()
        {
            var getEntriesAndExits = await _movimentationRepository.GetAllMovimentations();
            return Ok(getEntriesAndExits);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimentations>> DeleteMovimentations(int id)
        {

            //var getMovimentations = _movimentationRepository.Get(id);
            //if (getMovimentations == null)
            //    return NotFound();

            //await _movimentationRepository.Delete(getMovimentations.Id);
            //return NoContent();
                uow.BeginTransaction();
                try
                {
                var item = await _movimentationRepository.Get(id);
                
                    if (item == null)
                    {
                        return NotFound();
                    }
                    _movimentationRepository.Delete(id);
                     uow.Commit();

                    return NoContent();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            
          
            

        }
    }
}
