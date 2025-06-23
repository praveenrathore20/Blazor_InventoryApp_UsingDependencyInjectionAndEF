using Domain.Models.Response;
using Infrastructure.Persistence.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<List<InventoryModel>> GetInventoryList();
        Task<Inventory> CreateAsync(Inventory inventory);
        Task<InventoryModel> GetByIdAsync(int id);
    }
}
