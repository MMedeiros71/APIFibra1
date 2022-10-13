using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Extensions;
using API.Helpers;
using APIFibra.Data;
using APIFibra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIFibra.Controllers
{
    [Authorize]
    public class AtivoController : BaseApiController
    {
        private readonly AtivoRepository _ativoRepository;

        public AtivoController(AtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ativo>>> GetAtivos([FromQuery] AtivoParams ativoParams)
        {
            var ativos = await _ativoRepository.GetAtivosAsync(ativoParams);
            
            Response.AddPaginationHeader(ativos.CurrentPage, ativos.PageSize,
                ativos.TotalCount, ativos.TotalPages);
            
            return Ok(ativos);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Ativo>> GetAtivo(int id)
        {
            var ativo = await _ativoRepository.GetAtivoByIdAsync(id);
            return Ok(ativo);
        }
        
        [HttpPost]
        public async Task<ActionResult> IncluiAtivo([FromBody] Ativo ativo)
        {
            _ativoRepository.IncluiAtivo(ativo);
            if(await _ativoRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Falha ao criar ativo");
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateNoticia([FromBody] Ativo ativo)
        {
            _ativoRepository.UpdateAtivo(ativo);
            if (await _ativoRepository.SaveAllAsync()) return NoContent();
            
            return BadRequest("Falha ao atualizar ativo");
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNoticia(int id)
        {
            var ativo = await _ativoRepository.GetAtivoByIdAsync(id);

            if (ativo == null)
            {
                return NotFound();
            }

            try
            {
                _ativoRepository.DeleteAtivo(ativo);
                await _ativoRepository.SaveAllAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao excluir o ativo.");
            }
        }
    }
}