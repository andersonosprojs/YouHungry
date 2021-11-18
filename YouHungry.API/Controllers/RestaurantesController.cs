using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;

        public RestaurantesController(IRestauranteService restauranteService) => _restauranteService = restauranteService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestauranteDTO>>> Get()
        {
            var restaurantesDTO = await _restauranteService.GetRestaurantesAsync();

            if (restaurantesDTO == null)
                return NotFound("Restaurantes não encontrados.");

            return Ok(restaurantesDTO);
        }

        [HttpGet("{id:int}", Name = "GetRestaurante")]
        public async Task<ActionResult<RestauranteDTO>> Get(long? id)
        {
            var restauranteDTO = await _restauranteService.GetByIdAsync(id);

            if (restauranteDTO == null)
                return NotFound("Restaurante não encontrado.");

            return Ok(restauranteDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RestauranteDTO restauranteDTO)
        {
            if (restauranteDTO == null)
                BadRequest("Dados inválidos.");

            await _restauranteService.AddAsync(restauranteDTO);

            return new CreatedAtRouteResult("GetRestaurante", new { id = restauranteDTO.Id }, restauranteDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] RestauranteDTO restauranteDTO)
        {
            if (restauranteDTO == null)
                return BadRequest("Dados inválidos.");

            if (id != restauranteDTO.Id)
                return BadRequest("Identicação do Restaurante inválida");

            await _restauranteService.UpdateAsync(restauranteDTO);

            return Ok(restauranteDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RestauranteDTO>> Delete(long id)
        {
            var restauranteDTO = await _restauranteService.GetByIdAsync(id);

            if (restauranteDTO == null)
                return NotFound("Restaurante não encontrado.");

            await _restauranteService.RemoveAsync(id);

            return Ok(restauranteDTO);
        }
    }
}
