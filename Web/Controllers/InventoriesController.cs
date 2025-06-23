using Domain.Constant;
using Domain.Models.Response;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{

    public class InventoriesController : Controller
    {
        #region Private Variables
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryTypeService _inventoryTypeService;
        #endregion
        #region Constructor
        public InventoriesController(IInventoryService inventoryService, IInventoryTypeService inventoryTypeService)
        {
            _inventoryService = inventoryService;
            _inventoryTypeService = inventoryTypeService;
        }

        #endregion
        // GET: InventoryController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var data = await _inventoryService.GetInventoryList();
            return Ok(data);
        }

        [HttpPost("CreateInventory")]
        public async Task<ActionResult<InventoryModel>> CreateInventory()
        {

            InventoryModel newInventory = new InventoryModel()
            {
                Name = "No name set",
                Description = string.Empty,
                CompanySapcode = UtilityConstant.CompanySapcode,
                InventoryTypeId = UtilityConstant.InventoryTypeId,
                InventoryStatusId = UtilityConstant.InventoryStatusId,
                CreationDate = DateTime.Now,
                ReferenceDate = DateTime.Now.AddDays(30),
                EntryDate = DateTime.Now.AddDays(30),
                Notes = string.Empty,
                QuantityDefault = UtilityConstant.DefaultQuantity,
                IsExcelUploadDisabled = false,

            };

            try
            {
                // Assuming CreateAsync returns the saved entity with generated Id
                var createdInventory = await _inventoryService.CreateInventory(newInventory);

                if (createdInventory == null || createdInventory.IvId == 0)
                    return BadRequest("Failed to create inventory.");

                return CreatedAtAction(nameof(GetById), new { id = createdInventory.IvId }, createdInventory);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error creating inventory: {ex.Message}");
            }
        }
              
        public async Task<ActionResult<InventoryModel>> GetById(int id)
        {
            var inventory = await _inventoryService.GetInventoryById(id);

            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }


        [HttpPost("UpdateInventory")]
        public async Task<ActionResult<InventoryModel>> UpdateInventory([FromBody] InventoryModel inventoryModel)
        {
            try
            {
                var createdInventory = await _inventoryService.UpdateInventory(inventoryModel);

                if (createdInventory == null || createdInventory.IvId == 0)
                    return BadRequest("Failed to update inventory.");

                return CreatedAtAction(nameof(GetById), new { id = createdInventory.IvId }, createdInventory);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error updating inventory: {ex.Message}");
            }
        }

        [HttpGet("GetInventoryType")]
        public async Task<ActionResult<List<InventoryTypeModel>>> GetInventoryType()
        {
            try
            {
                var inventoryTypeList = await _inventoryTypeService.GetInventoryTypeList();
                return Ok(inventoryTypeList);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Failed to get inventory type list: {ex.Message}");
            }
        }
    }
}
