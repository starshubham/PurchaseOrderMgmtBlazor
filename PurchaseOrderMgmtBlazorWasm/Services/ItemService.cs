using Common.Models;
using PurchaseOrderMgmtBlazorWasm.Services.Interfaces;
using System.Net.Http.Json;

namespace PurchaseOrderMgmtBlazorWasm.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;
        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Item>>("/api/Items") ?? new List<Item>();
        }
    }
}
