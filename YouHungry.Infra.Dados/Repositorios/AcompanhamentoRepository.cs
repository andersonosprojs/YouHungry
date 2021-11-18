using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Infra.Dados.Contexto;

namespace YouHungry.Infra.Dados.Repositories
{
    public class AcompanhamentoRepository : IAcompanhamentoRepository
    {
        private readonly AppDbContext _acompanhamentoContext;

        public AcompanhamentoRepository(AppDbContext context)
        {
            _acompanhamentoContext = context;
        }

        public async Task<Acompanhamento> CreateAsync(Acompanhamento acompanhamento)
        {
            _acompanhamentoContext.Add(acompanhamento);
            await _acompanhamentoContext.SaveChangesAsync();

            return acompanhamento;
        }

        public async Task<Acompanhamento> GetByIdAsync(long? id)
        {
            return await _acompanhamentoContext.Acompanhamentos.FindAsync(id);
        }

        public async Task<IEnumerable<Acompanhamento>> GetAcompanhamentosAsync()
        {
            return await _acompanhamentoContext.Acompanhamentos.ToListAsync();
        }

        public async Task<Acompanhamento> RemoveAsync(Acompanhamento acompanhamento)
        {
            _acompanhamentoContext.Remove(acompanhamento);
            await _acompanhamentoContext.SaveChangesAsync();

            return acompanhamento;
        }

        public async Task<Acompanhamento> UpdateAsync(Acompanhamento acompanhamento)
        {
            _acompanhamentoContext.Update(acompanhamento);
            await _acompanhamentoContext.SaveChangesAsync();

            return acompanhamento;
        }
    }
}
