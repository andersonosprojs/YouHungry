using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Dominio.Entidades;

namespace YouHungry.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetByIdAsync(long? id);

        Task<Usuario> CreateAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task<Usuario> RemoveAsync(Usuario usuario);
    }
}