using Application.DTOs;
using Domain.Constant;
using Domain.Models.Response;
using Domain.RepositoryInterfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private readonly IConfiguration _config;

        public InventoryRepository(dbcontext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task<List<InventoryModel>> GetInventoryList()
        {
            var companySapcode = _config.GetSection("applicationConfig")["CompanySapCode"];

            return await (from inventory in _context.Inventories.Where(x => x.CompanySapcode == companySapcode && x.InventoryStatusId != UtilityConstant.InventoryStatusClosed)
                          select new InventoryModel
                          {
                              IvId = inventory.IvId,
                              InventoryStatusId = inventory.InventoryStatusId,
                              CompanySapcode = inventory.CompanySapcode,
                              CompanyName = inventory.CompanySapcodeNavigation.Name,
                              InventoryTypeId = inventory.InventoryTypeId,
                              InventoryTypeDescription = inventory.InventoryType.Description,
                              InventoryStatusName = inventory.InventoryStatus.Name,
                              Name = inventory.Name,
                              Description = inventory.Description,
                              Notes = inventory.Notes,
                              CreationDate = inventory.CreationDate,
                              ReferenceDate = inventory.ReferenceDate,
                              EntryDate = inventory.EntryDate,
                              QuantityDefault = inventory.QuantityDefault,
                              IsExcelUploadDisabled = inventory.IsExcelUploadDisabled,
                              LastTouchUser = inventory.LastTouchUser,
                              LastTouchDate = inventory.LastTouchDate,
                              inventoryShopCount = inventory.InventoryShops.Count,
                              inventoryShopUserCount = inventory.InventoryShopUsers.Count,
                          }).ToListAsync();
        }

        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            // Now inventory.IvId will be populated with the new ID from DB
            return inventory;
        }
        public async Task<InventoryModel> GetByIdAsync(int id)
        {

            return await (from inventory in _context.Inventories.Where(x => x.IvId == id)
                          select new InventoryModel
                          {
                              IvId = inventory.IvId,
                              InventoryStatusId = inventory.InventoryStatusId,
                              CompanySapcode = inventory.CompanySapcode,
                              CompanyName = inventory.CompanySapcodeNavigation.Name,
                              InventoryTypeId = inventory.InventoryTypeId,
                              InventoryTypeDescription = inventory.InventoryType.Description,
                              InventoryStatusName = inventory.InventoryStatus.Name,
                              Name = inventory.Name,
                              Description = inventory.Description,
                              Notes = inventory.Notes,
                              CreationDate = inventory.CreationDate,
                              ReferenceDate = inventory.ReferenceDate,
                              EntryDate = inventory.EntryDate,
                              QuantityDefault = inventory.QuantityDefault,
                              IsExcelUploadDisabled = inventory.IsExcelUploadDisabled,
                              LastTouchUser = inventory.LastTouchUser,
                              LastTouchDate = inventory.LastTouchDate,
                              inventoryShopCount = inventory.InventoryShops.Count,
                              inventoryShopUserCount = inventory.InventoryShopUsers.Count,
                          }).FirstOrDefaultAsync();
        }

    }
}
