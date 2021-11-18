using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;

namespace YouHungry.Aplicacao.Interfaces
{
    public interface IPratoService
    {
        Task<IEnumerable<PratoDTO>> GetPratosAsync();
        Task<PratoDTO> GetByIdAsync(long? id);

        Task AddAsync(PratoDTO PratoDTO);
        Task UpdateAsync(PratoDTO PratoDTO);
        Task RemoveAsync(long? id);
    }
}
