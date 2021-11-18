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

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
        {
            var usuariosEntity = await _usuarioRepository.GetUsuariosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuariosEntity);
        }

        public async Task<UsuarioDTO> GetByIdAsync(long? id)
        {
            var usuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task AddAsync(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.CreateAsync(usuarioEntity);
        }

        public async Task UpdateAsync(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.UpdateAsync(usuarioEntity);
        }

        public async Task RemoveAsync(long? id)
        {
            var usuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            await _usuarioRepository.RemoveAsync(usuarioEntity);
        }
    }
}
