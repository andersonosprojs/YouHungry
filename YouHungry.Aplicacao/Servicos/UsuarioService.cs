using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Aplicacao.Interfaces;
using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;

namespace YouHungry.Aplicacao.Services
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _usuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
        {
            var usuariosEntity = await _usuarioRepository.GetUsuariosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuariosEntity);
        }

        public async Task<UsuarioDTO> GetByIdAsync(long? id)
        {
            var UsuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(UsuarioEntity);
        }

        public async Task AddAsync(UsuarioDTO UsuarioDTO)
        {
            var UsuarioEntity = _mapper.Map<Usuario>(UsuarioDTO);
            await _usuarioRepository.CreateAsync(UsuarioEntity);
        }

        public async Task UpdateAsync(UsuarioDTO UsuarioDTO)
        {
            var UsuarioEntity = _mapper.Map<Usuario>(UsuarioDTO);
            await _usuarioRepository.UpdateAsync(UsuarioEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var UsuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            await _usuarioRepository.RemoveAsync(UsuarioEntity);
        }
    }
}
