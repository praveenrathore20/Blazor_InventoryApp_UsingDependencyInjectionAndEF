using Domain.Models.Response;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Infrastructure.Persistence.Entities;
using Mapster;
using Microsoft.Extensions.Configuration;


namespace Application.Services
{
    public class InventoryService : IInventoryService
    {
        #region Private Variables
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public InventoryService(IInventoryRepository inventoryRepository, IConfiguration config)
        {
            _inventoryRepository = inventoryRepository;
            _config = config;
        }

        public async Task<InventoryModel> CreateInventory(InventoryModel inventory)
        {
            Inventory entity = inventory.Adapt<Inventory>();
            entity = await _inventoryRepository.AddAsync(entity);
            return entity.Adapt<InventoryModel>();
        }

        public async Task<InventoryModel> GetInventoryById(int id)
        {
            InventoryModel response = await _inventoryRepository.GetByIdAsync(id);
            return response;
        }
        #endregion

        public async Task<List<InventoryModel>> GetInventoryList()
        {           
            var inventories = await _inventoryRepository.GetInventoryList();
            return inventories;// inventories.Adapt<List<InventoryModel>>(); //mapping object
        }

        public async Task<InventoryModel> UpdateInventory(InventoryModel inventory)
        {
            Inventory entity = inventory.Adapt<Inventory>();
            entity = await _inventoryRepository.UpdateAsync(entity);
            return entity.Adapt<InventoryModel>();
        }
    }
}
