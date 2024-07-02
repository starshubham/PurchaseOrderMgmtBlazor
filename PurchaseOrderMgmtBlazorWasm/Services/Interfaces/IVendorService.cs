using Common.Models;

namespace PurchaseOrderMgmtBlazorWasm.Services.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetAllVendors();
    }
}
