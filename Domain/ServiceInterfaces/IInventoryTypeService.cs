using Domain.Models.Response;

namespace Domain.ServiceInterfaces
{
    public interface IInventoryTypeService
    {
        public Task<List<InventoryTypeModel>> GetInventoryTypeList();     
    }
}
