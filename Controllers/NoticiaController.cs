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
    public class NoticiaController : BaseApiController
    {
        private readonly NoticiaRepository _noticiaRepository;

        public NoticiaController(NoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticia>>> GetNoticias([FromQuery] UserParams userParams)
        {
            var users = await _noticiaRepository.GetNoticiasAsync(userParams);
            
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);
            
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticia>> GetNoticia(int id)
        {
            var noticia = await _noticiaRepository.GetNoticiaByIdAsync(id);
            return Ok(noticia);
        }

        [HttpPost]
        public async Task<ActionResult> IncluiNoticia([FromBody] Noticia noticia)
        {
            _noticiaRepository.IncluiNoticia(noticia);
            if(await _noticiaRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Falha ao criar notícia");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNoticia([FromBody] Noticia noticia)
        {
            _noticiaRepository.UpdateNoticia(noticia);
            if (await _noticiaRepository.SaveAllAsync()) return NoContent();
            
            return BadRequest("Falha ao atualizar notícia");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNoticia(int id)
        {
            var noticia = await _noticiaRepository.GetNoticiaByIdAsync(id);

            if (noticia == null)
            {
                return NotFound();
            }

            try
            {
                _noticiaRepository.DeleteNoticia(noticia);
                await _noticiaRepository.SaveAllAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao excluir a notícia.");
            }
        }
    }
}