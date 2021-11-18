using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;
using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;

namespace YouHungry.Aplicacao.Services
{
    public class RestauranteService : IRestauranteService
    {

        private IRestauranteRepository _restauranteRepository;
        private readonly IMapper _mapper;

        public RestauranteService(IRestauranteRepository restauranteRepository, IMapper mapper)
        {
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestauranteDTO>> GetRestaurantesAsync()
        {
            var restaurantesEntity = await _restauranteRepository.GetRestaurantesAsync();
            return _mapper.Map<IEnumerable<RestauranteDTO>>(restaurantesEntity);
        }

        public async Task<RestauranteDTO> GetByIdAsync(long? id)
        {
            var restauranteEntity = await _restauranteRepository.GetByIdAsync(id);
            return _mapper.Map<RestauranteDTO>(restauranteEntity);
        }

        public async Task AddAsync(RestauranteDTO restauranteDTO)
        {
            var pestauranteEntity = _mapper.Map<Restaurante>(restauranteDTO);
            await _restauranteRepository.CreateAsync(pestauranteEntity);
        }

        public async Task UpdateAsync(RestauranteDTO restauranteDTO)
        {
            var restauranteEntity = _mapper.Map<Restaurante>(restauranteDTO);
            await _restauranteRepository.UpdateAsync(restauranteEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var restauranteEntity = await _restauranteRepository.GetByIdAsync(id);
            await _restauranteRepository.RemoveAsync(restauranteEntity);
        }
    }
}
