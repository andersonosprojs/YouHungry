using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;

namespace YouHungry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
        {
            var usuariosDTO = await _usuarioService.GetUsuariosAsync();

            if (usuariosDTO == null)
                return NotFound("Usuários não encontrados.");

            return Ok(usuariosDTO);
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(long? id)
        {
            var usuarioDTO = await _usuarioService.GetByIdAsync(id);

            if (usuarioDTO == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                BadRequest("Dados inválidos.");

            await _usuarioService.AddAsync(usuarioDTO);

            return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Dados inválidos.");

            if (id != usuarioDTO.Id)
                return BadRequest("Identicação do Usuário inválida");

            await _usuarioService.UpdateAsync(usuarioDTO);

            return Ok(usuarioDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(long id)
        {
            var usuarioDTO = await _usuarioService.GetByIdAsync(id);

            if (usuarioDTO == null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.RemoveAsync(id);

            return Ok(usuarioDTO);
        }
    }
}
