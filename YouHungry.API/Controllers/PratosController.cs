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
    public class PratosController : ControllerBase
    {
        private readonly IPratoService _pratoService;

        public PratosController(IPratoService pratoService) => _pratoService = pratoService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PratoDTO>>> Get()
        {
            var pratosDTO = await _pratoService.GetPratosAsync();

            if (pratosDTO == null)
                return NotFound("Pratos não encontrados.");

            return Ok(pratosDTO);
        }

        [HttpGet("{id:int}", Name = "GetPrato")]
        public async Task<ActionResult<PratoDTO>> Get(long? id)
        {
            var pratoDTO = await _pratoService.GetByIdAsync(id);

            if (pratoDTO == null)
                return NotFound("Prato não encontrado.");

            return Ok(pratoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PratoDTO pratoDTO)
        {
            if (pratoDTO == null)
                BadRequest("Dados inválidos.");

            await _pratoService.AddAsync(pratoDTO);

            return new CreatedAtRouteResult("GetPrato", new { id = pratoDTO.Id }, pratoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(long id, [FromBody] PratoDTO pratoDTO)
        {
            if (pratoDTO == null)
                return BadRequest("Dados inválidos.");

            if (id != pratoDTO.Id)
                return BadRequest("Identicação do Prato inválida");

            await _pratoService.UpdateAsync(pratoDTO);

            return Ok(pratoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PratoDTO>> Delete(long id)
        {
            var pratoDTO = await _pratoService.GetByIdAsync(id);

            if (pratoDTO == null)
                return NotFound("Prato não encontrado.");

            await _pratoService.RemoveAsync(id);

            return Ok(pratoDTO);
        }
    }
}
