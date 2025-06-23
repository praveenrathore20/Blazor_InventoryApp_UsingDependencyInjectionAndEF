using Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceInterfaces
{
    public interface IInventoryService
    {
        public Task<List<InventoryModel>> GetInventoryList();
        public Task<InventoryModel> CreateInventory(InventoryModel inventory);
        public Task<InventoryModel> UpdateInventory(InventoryModel inventory);
        public Task<InventoryModel> GetInventoryById(int id);
    }
}
