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
    public class AcompanhamentosController : ControllerBase
    {
        private readonly IAcompanhamentoService _acompanhamentoService;

        public AcompanhamentosController(IAcompanhamentoService acompanhamentoService) => _acompanhamentoService = acompanhamentoService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcompanhamentoDTO>>> Get()
        {
            var acompanhamentosDTO = await _acompanhamentoService.GetAcompanhamentosAsync();

            if (acompanhamentosDTO == null)
                return NotFound("Acompanhamentos não encontrados.");

            return Ok(acompanhamentosDTO);
        }

        [HttpGet("{id:int}", Name = "GetAcompanhamento")]
        public async Task<ActionResult<AcompanhamentoDTO>> Get(long? id)
        {
            var acompanhamentoDTO = await _acompanhamentoService.GetByIdAsync(id);

            if (acompanhamentoDTO == null)
                return NotFound("Acompanhamento não encontrado.");

            return Ok(acompanhamentoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AcompanhamentoDTO acompanhamentoDTO)
        {
            if (acompanhamentoDTO == null)
                BadRequest("Dados inválidos.");

            await _acompanhamentoService.AddAsync(acompanhamentoDTO);

            return new CreatedAtRouteResult("GetAcompanhamento", new { id = acompanhamentoDTO.Id }, acompanhamentoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AcompanhamentoDTO acompanhamentoDTO)
        {
            if (acompanhamentoDTO == null)
                return BadRequest("Dados inválidos.");

            if (id != acompanhamentoDTO.Id)
                return BadRequest("Identicação do Acompanhamento inválida");

            await _acompanhamentoService.UpdateAsync(acompanhamentoDTO);

            return Ok(acompanhamentoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AcompanhamentoDTO>> Delete(long id)
        {
            var acompanhamentoDTO = await _acompanhamentoService.GetByIdAsync(id);

            if (acompanhamentoDTO == null)
                return NotFound("Acompanhamento não encontrado.");

            await _acompanhamentoService.RemoveAsync(id);

            return Ok(acompanhamentoDTO);
        }
    }
}
