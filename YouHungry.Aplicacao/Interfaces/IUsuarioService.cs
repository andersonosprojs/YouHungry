using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;

namespace YouHungry.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> GetByIdAsync(long? id);

        Task AddAsync(UsuarioDTO UsuarioDTO);
        Task UpdateAsync(UsuarioDTO UsuarioDTO);
        Task RemoveAsync(long? id);
    }
}
