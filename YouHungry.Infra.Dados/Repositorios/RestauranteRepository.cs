using YouHungry.Dominio.Entidades;
using YouHungry.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Infra.Dados.Contexto;

namespace YouHungry.Infra.Dados.Repositories
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly AppDbContext _restauranteContext;

        public RestauranteRepository(AppDbContext context)
        {
            _restauranteContext = context;
        }

        public async Task<Restaurante> CreateAsync(Restaurante restaurante)
        {
            _restauranteContext.Add(restaurante);
            await _restauranteContext.SaveChangesAsync();

            return restaurante;
        }

        public async Task<Restaurante> GetByIdAsync(long? id)
        {
            return await _restauranteContext.Restaurantes.FindAsync(id);
        }

        public async Task<IEnumerable<Restaurante>> GetRestaurantesAsync()
        {
            return await _restauranteContext.Restaurantes.ToListAsync();
        }

        public async Task<Restaurante> RemoveAsync(Restaurante restaurante)
        {
            _restauranteContext.Remove(restaurante);
            await _restauranteContext.SaveChangesAsync();

            return restaurante;
        }

        public async Task<Restaurante> UpdateAsync(Restaurante restaurante)
        {
            _restauranteContext.Update(restaurante);
            await _restauranteContext.SaveChangesAsync();

            return restaurante;
        }
    }
}
