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

        public RestauranteService(IRestauranteRepository RestauranteRepository, IMapper mapper)
        {
            _restauranteRepository = RestauranteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestauranteDTO>> GetRestaurantesAsync()
        {
            var RestaurantesEntity = await _restauranteRepository.GetRestaurantesAsync();
            return _mapper.Map<IEnumerable<RestauranteDTO>>(RestaurantesEntity);
        }

        public async Task<RestauranteDTO> GetByIdAsync(long? id)
        {
            var RestauranteEntity = await _restauranteRepository.GetByIdAsync(id);
            return _mapper.Map<RestauranteDTO>(RestauranteEntity);
        }

        public async Task AddAsync(RestauranteDTO RestauranteDTO)
        {
            var RestauranteEntity = _mapper.Map<Restaurante>(RestauranteDTO);
            await _restauranteRepository.CreateAsync(RestauranteEntity);
        }

        public async Task UpdateAsync(RestauranteDTO RestauranteDTO)
        {
            var RestauranteEntity = _mapper.Map<Restaurante>(RestauranteDTO);
            await _restauranteRepository.UpdateAsync(RestauranteEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var RestauranteEntity = await _restauranteRepository.GetByIdAsync(id);
            await _restauranteRepository.RemoveAsync(RestauranteEntity);
        }
    }
}
