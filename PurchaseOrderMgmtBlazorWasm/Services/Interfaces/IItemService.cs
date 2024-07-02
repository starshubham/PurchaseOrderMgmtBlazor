using Common.Models;

namespace PurchaseOrderMgmtBlazorWasm.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItems();
    }
}
