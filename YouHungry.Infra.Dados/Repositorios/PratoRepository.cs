using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Infra.Dados.Contexto;

namespace YouHungry.Infra.Dados.Repositories
{
    public class PratoRepository : IPratoRepository
    {
        private readonly AppDbContext _pratoContext;

        public PratoRepository(AppDbContext context)
        {
            _pratoContext = context;
        }

        public async Task<Prato> CreateAsync(Prato prato)
        {
            _pratoContext.Add(prato);
            await _pratoContext.SaveChangesAsync();

            return prato;
        }

        public async Task<Prato> GetByIdAsync(long? id)
        {
            return await _pratoContext.Pratos.FindAsync(id);
        }

        public async Task<IEnumerable<Prato>> GetPratosAsync()
        {
            return await _pratoContext.Pratos.ToListAsync();
        }

        public async Task<Prato> RemoveAsync(Prato prato)
        {
            _pratoContext.Remove(prato);
            await _pratoContext.SaveChangesAsync();

            return prato;
        }

        public async Task<Prato> UpdateAsync(Prato prato)
        {
            _pratoContext.Update(prato);
            await _pratoContext.SaveChangesAsync();

            return prato;
        }
    }
}
