using System.Threading.Tasks;
using APIFibra.Data;
using APIFibra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIFibra.Controllers
{
    [Authorize]
    public class CotaIndiceController : BaseApiController
    {
        private readonly CotaIndiceRepository _cotaIndiceRepository;


        public CotaIndiceController(CotaIndiceRepository cotaIndiceRepository)
        {
            _cotaIndiceRepository = cotaIndiceRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<CotaIndice>> GetNoticia()
        {
            var noticia = await _cotaIndiceRepository.GetNoticiaByIdAsync();
            
            return Ok(noticia);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateCotaIndice([FromBody] CotaIndice cotaIndice)
        {
            if (await _cotaIndiceRepository.CotaIndiceCount() > 0)
            {
                cotaIndice.ID = 1;
                _cotaIndiceRepository.UpdateCotaIndice(cotaIndice);
                
                if (await _cotaIndiceRepository.SaveAllAsync()) return NoContent();
            
                return BadRequest("Falha ao atualizar Cota/Índice");    
            }
            
            _cotaIndiceRepository.IncluiCotaIndice(cotaIndice);
            if(await _cotaIndiceRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Falha ao criar Cota/Índice");
        }
        
    }
}