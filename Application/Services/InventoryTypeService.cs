using Domain.Models.Response;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Mapster;
using Microsoft.Extensions.Configuration;


namespace Application.Services
{
    public class InventoryTypeService : IInventoryTypeService
    {
        #region Private Variables
        private readonly IInventoryTypeRepository _inventoryTypeRepository;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public InventoryTypeService(IInventoryTypeRepository inventoryTypeRepository, IConfiguration config)
        {
            _inventoryTypeRepository = inventoryTypeRepository;
            _config = config;
        }
        #endregion

        public async Task<List<InventoryTypeModel>> GetInventoryTypeList()
        {
            var inventoryTypes = await _inventoryTypeRepository.GetAllAsync();
            return inventoryTypes.Adapt<List<InventoryTypeModel>>(); //mapping object
        }
    }
}
