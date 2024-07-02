using Common.Models;
using PurchaseOrderMgmtBlazorWasm.Services.Interfaces;
using System.Net.Http.Json;

namespace PurchaseOrderMgmtBlazorWasm.Services
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient _httpClient;

        public VendorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            var vendors = await _httpClient.GetFromJsonAsync<IEnumerable<Vendor>>("api/Vendors") ?? new List<Vendor>();
            return vendors;
        }
    }
}
