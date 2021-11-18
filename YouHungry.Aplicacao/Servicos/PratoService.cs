using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;
using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;

namespace YouHungry.Aplicacao.Services
{
    public class PratoService : IPratoService
    {

        private IPratoRepository _pratoRepository;
        private readonly IMapper _mapper;

        public PratoService(IPratoRepository PratoRepository, IMapper mapper)
        {
            _pratoRepository = PratoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PratoDTO>> GetPratosAsync()
        {
            var PratosEntity = await _pratoRepository.GetPratosAsync();
            return _mapper.Map<IEnumerable<PratoDTO>>(PratosEntity);
        }

        public async Task<PratoDTO> GetByIdAsync(long? id)
        {
            var PratoEntity = await _pratoRepository.GetByIdAsync(id);
            return _mapper.Map<PratoDTO>(PratoEntity);
        }

        public async Task AddAsync(PratoDTO PratoDTO)
        {
            var PratoEntity = _mapper.Map<Prato>(PratoDTO);
            await _pratoRepository.CreateAsync(PratoEntity);
        }

        public async Task UpdateAsync(PratoDTO PratoDTO)
        {
            var PratoEntity = _mapper.Map<Prato>(PratoDTO);
            await _pratoRepository.UpdateAsync(PratoEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var PratoEntity = await _pratoRepository.GetByIdAsync(id);
            await _pratoRepository.RemoveAsync(PratoEntity);
        }
    }
}
