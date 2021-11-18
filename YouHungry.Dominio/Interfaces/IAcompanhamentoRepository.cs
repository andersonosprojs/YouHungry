using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Dominio.Entidades;

namespace YouHungry.Dominio.Interfaces
{
    public interface IAcompanhamentoRepository
    {
        Task<IEnumerable<Acompanhamento>> GetAcompanhamentosAsync();
        Task<Acompanhamento> GetByIdAsync(long? id);

        Task<Acompanhamento> CreateAsync(Acompanhamento acompanhamento);
        Task<Acompanhamento> UpdateAsync(Acompanhamento acompanhamento);
        Task<Acompanhamento> RemoveAsync(Acompanhamento acompanhamento);
    }
}