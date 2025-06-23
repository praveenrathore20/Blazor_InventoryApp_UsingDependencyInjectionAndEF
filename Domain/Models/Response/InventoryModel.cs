namespace Domain.Models.Response
{
    public class InventoryModel
    {
        public int IvId { get; set; }
        public string CompanySapcode { get; set; }
        public string CompanyName { get; set; }
        public int InventoryTypeId { get; set; }
        public string InventoryTypeDescription { get; set; }
        public int InventoryStatusId { get; set; }
        public string InventoryStatusName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int QuantityDefault { get; set; }
        public bool IsExcelUploadDisabled { get; set; }
        public string? LastTouchUser { get; set; }
        public DateTime? LastTouchDate { get; set; }
        public int inventoryShopCount { get; set; }
        public int inventoryShopUserCount { get; set; }
        public int inventoryShopBUCount { get; set; }
    }
}
