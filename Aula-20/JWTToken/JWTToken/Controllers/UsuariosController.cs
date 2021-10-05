using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTToken.Models;
using System.Security.Cryptography;
using System.Text;
using JWTToken.Utils;
using JWTToken.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly JWTTokenTesteDBContext _context;

        public UsuariosController(JWTTokenTesteDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPut("{id}"]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutUsuario(int id, SalvarUsuarioDto dto)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest("Usuario nao econtrado");
            }

            usuario.Nome = dto.Nome;
            usuario.Perfil = dto.Perfil;
            usuario.Email = dto.Email;
            //Método vai gerar um senha criptografada
            usuario.Senha = PasswordUtil.GeneratePassword(dto.Senha);

            _context.Entry(usuario).State = 
        }
    }
}
