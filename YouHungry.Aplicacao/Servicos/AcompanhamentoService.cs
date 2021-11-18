using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;
using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;

namespace YouHungry.Aplicacao.Services
{
    public class AcompanhamentoService : IAcompanhamentoService
    {

        private IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly IMapper _mapper;

        public AcompanhamentoService(IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _acompanhamentoRepository = acompanhamentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AcompanhamentoDTO>> GetAcompanhamentosAsync()
        {
            var acompanhamentosEntity = await _acompanhamentoRepository.GetAcompanhamentosAsync();
            return _mapper.Map<IEnumerable<AcompanhamentoDTO>>(acompanhamentosEntity);
        }

        public async Task<AcompanhamentoDTO> GetByIdAsync(long? id)
        {
            var acompanhamentoEntity = await _acompanhamentoRepository.GetByIdAsync(id);
            return _mapper.Map<AcompanhamentoDTO>(acompanhamentoEntity);
        }

        public async Task AddAsync(AcompanhamentoDTO acompanhamentoDTO)
        {
            var acompanhamentoEntity = _mapper.Map<Acompanhamento>(acompanhamentoDTO);
            await _acompanhamentoRepository.CreateAsync(acompanhamentoEntity);
        }

        public async Task UpdateAsync(AcompanhamentoDTO acompanhamentoDTO)
        {
            var acompanhamentoEntity = _mapper.Map<Acompanhamento>(acompanhamentoDTO);
            await _acompanhamentoRepository.UpdateAsync(acompanhamentoEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var acompanhamentoEntity = await _acompanhamentoRepository.GetByIdAsync(id);
            await _acompanhamentoRepository.RemoveAsync(acompanhamentoEntity);
        }
    }
}
