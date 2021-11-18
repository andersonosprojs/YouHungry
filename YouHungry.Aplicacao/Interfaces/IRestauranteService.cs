using System.Collections.Generic;
using System.Threading.Tasks;
using YouHungry.Aplicacao.DTOs;

namespace YouHungry.Aplicacao.Interfaces
{
    public interface IRestauranteService
    {
        Task<IEnumerable<RestauranteDTO>> GetRestaurantesAsync();
        Task<RestauranteDTO> GetByIdAsync(long? id);

        Task AddAsync(RestauranteDTO RestauranteDTO);
        Task UpdateAsync(RestauranteDTO RestauranteDTO);
        Task RemoveAsync(long? id);
    }
}
