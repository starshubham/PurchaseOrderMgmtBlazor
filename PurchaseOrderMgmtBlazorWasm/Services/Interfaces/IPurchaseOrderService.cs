using PurchaseOrderMgmtBlazorWasm.ViewModel;

namespace PurchaseOrderMgmtBlazorWasm.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderVM>> GetAllPurchaseOrders();
        Task<PurchaseOrderVM> GetPurchaseOrder(string id);
        Task<HttpResponseMessage> CreatePurchaseOrder(PurchaseOrderVM po);
        Task<HttpResponseMessage> UpdatePurchaseOrder(PurchaseOrderVM po);
        Task<HttpResponseMessage> DeletePurchaseOrder(string id);
        Task<bool> CheckIfPurchaseOrderExists(string id);
    }
}
