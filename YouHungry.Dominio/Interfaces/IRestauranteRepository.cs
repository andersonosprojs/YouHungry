using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Dominio.Entidades;

namespace YouHungry.Dominio.Interfaces
{
    public interface IRestauranteRepository
    {
        Task<IEnumerable<Restaurante>> GetRestaurantesAsync();
        Task<Restaurante> GetByIdAsync(long? id);

        Task<Restaurante> CreateAsync(Restaurante restaurante);
        Task<Restaurante> UpdateAsync(Restaurante restaurante);
        Task<Restaurante> RemoveAsync(Restaurante restaurante);
    }
}