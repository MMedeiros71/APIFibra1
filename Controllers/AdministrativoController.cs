using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APIFibra.Data;
using APIFibra.DTOs;
using APIFibra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Controllers
{
    public class AdministrativoController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AdministrativoController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        
        [HttpPost("loginadm")]
        public async Task<ActionResult<UserAdmDto>> Login(LoginAdmDto loginAdmDto)
        {
            var usuario = await _context.Administrativos
                .SingleOrDefaultAsync(x => x.Usuario == loginAdmDto.Usuario);

            if (usuario == null) return Unauthorized("Usuário inválido");

            if (loginAdmDto.Senha != usuario.Senha) return Unauthorized("Senha inválida");
            
            return new UserAdmDto
            {
                Usuario = usuario.Usuario,
                Nivel = usuario.Nivel,
                Token = _tokenService.GenerateToken(usuario)
            };
        }
        
    }
}