using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;

namespace YouHungry.Aplicacao.Interfaces
{
    public interface IAcompanhamentoService
    {
        Task<IEnumerable<AcompanhamentoDTO>> GetAcompanhamentosAsync();
        Task<AcompanhamentoDTO> GetByIdAsync(long? id);

        Task AddAsync(AcompanhamentoDTO acompanhamentoDTO);
        Task UpdateAsync(AcompanhamentoDTO acompanhamentoDTO);
        Task RemoveAsync(long? id);
    }
}
