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

        public PratoService(IPratoRepository aratoRepository, IMapper mapper)
        {
            _pratoRepository = aratoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PratoDTO>> GetPratosAsync()
        {
            var pratosEntity = await _pratoRepository.GetPratosAsync();
            return _mapper.Map<IEnumerable<PratoDTO>>(pratosEntity);
        }

        public async Task<PratoDTO> GetByIdAsync(long? id)
        {
            var pratoEntity = await _pratoRepository.GetByIdAsync(id);
            return _mapper.Map<PratoDTO>(pratoEntity);
        }

        public async Task AddAsync(PratoDTO pratoDTO)
        {
            var pratoEntity = _mapper.Map<Prato>(pratoDTO);
            await _pratoRepository.CreateAsync(pratoEntity);
        }

        public async Task UpdateAsync(PratoDTO pratoDTO)
        {
            var pratoEntity = _mapper.Map<Prato>(pratoDTO);
            await _pratoRepository.UpdateAsync(pratoEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var pratoEntity = await _pratoRepository.GetByIdAsync(id);
            await _pratoRepository.RemoveAsync(pratoEntity);
        }
    }
}
