using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Dominio.Entidades;

namespace YouHungry.Dominio.Interfaces
{
    public interface IPratoRepository
    {
        Task<IEnumerable<Prato>> GetPratosAsync();
        Task<Prato> GetByIdAsync(long? id);

        Task<Prato> CreateAsync(Prato Prato);
        Task<Prato> UpdateAsync(Prato Prato);
        Task<Prato> RemoveAsync(Prato Prato);
    }
}