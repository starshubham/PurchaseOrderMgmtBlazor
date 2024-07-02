using Common.Models;
using PurchaseOrderMgmtBlazorWasm.Services.Interfaces;
using PurchaseOrderMgmtBlazorWasm.ViewModel;
using System.Net.Http.Json;

namespace PurchaseOrderMgmtBlazorWasm.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly HttpClient _httpClient;
        public PurchaseOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckIfPurchaseOrderExists(string id)
        {
            var response = await _httpClient.GetAsync($"/api/PurchaseOrders/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> CreatePurchaseOrder(PurchaseOrderVM po)
        {
            // Create a new PurchaseOrder object
            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                Code = po.DocNo,
                DocDate = po.DocDate,
                VCode = po.VendorCode,
                TotQuant = po.TotalQty,
                TotAmt = po.TotalAmt,
                Comment = po.Comment,
                Remarks = po.Remarks
            };

            // Save the purchase order to the database
            var purchaseOrderResponse = await _httpClient.PostAsJsonAsync("/api/PurchaseOrders", purchaseOrder);
            if (!purchaseOrderResponse.IsSuccessStatusCode)
            {
                return purchaseOrderResponse;
            }

            // Get the newly created purchase order from the response
            var createdPurchaseOrder = await purchaseOrderResponse.Content.ReadFromJsonAsync<PurchaseOrder>();

            foreach (var row in po.PO_Items)
            {
                PO_Item poItem = new PO_Item()
                {
                    ICode = row.ItemCode,
                    POCode = createdPurchaseOrder.Code,
                    IUnit = row.Unit,
                    Quantity = row.Quantity,
                    IRate = row.Rate,
                    Amount = row.Amount
                };
                // Save the PO_Items to the database
                var poItemsResponse = await _httpClient.PostAsJsonAsync("/api/PO_Item", poItem);
                if (!poItemsResponse.IsSuccessStatusCode)
                {
                    // Handle error response
                    return poItemsResponse;
                }
            }            
            return purchaseOrderResponse;
        }

        public async Task<HttpResponseMessage> DeletePurchaseOrder(string id)
        {
            var response = await _httpClient.DeleteAsync($"/api/PO_Item/{id}");

            if (response.IsSuccessStatusCode)
            {
                await _httpClient.DeleteAsync($"/api/PurchaseOrders/{id}");
            }
            return response;
        }

        public Task<IEnumerable<PurchaseOrderVM>> GetAllPurchaseOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseOrderVM> GetPurchaseOrder(string id)
        {
            PurchaseOrderVM purchaseOrderVM = new PurchaseOrderVM();

            var purchaseOrder = await _httpClient.GetFromJsonAsync<PurchaseOrder>($"/api/PurchaseOrders/{id}");

            var po_items = await _httpClient.GetFromJsonAsync<List<PO_Item>>($"/api/PO_Item/{id}");

            if (purchaseOrder != null )
            {
                purchaseOrderVM.DocNo = purchaseOrder.Code;
                purchaseOrderVM.DocDate = purchaseOrder.DocDate;
                purchaseOrderVM.VendorCode = purchaseOrder.VCode;
                purchaseOrderVM.TotalQty = purchaseOrder.TotQuant;
                purchaseOrderVM.TotalAmt = purchaseOrder.TotAmt;
                purchaseOrderVM.Comment = purchaseOrder.Comment;
                purchaseOrderVM.Remarks = purchaseOrder.Remarks;

                for (int i = 0; i < po_items.Count; i++)
                {
                    
                    var po_Item = new Row
                    {
                        SNo = i + 1,
                        ItemCode = po_items[i].ICode,
                        POCode = po_items[i].POCode,
                        Quantity = po_items[i].Quantity,
                        Amount = po_items[i].Amount,
                        Rate = po_items[i].IRate,
                        Unit = po_items[i].IUnit
                    };
                    purchaseOrderVM.PO_Items.Add(po_Item);
                }
            }
            return purchaseOrderVM;
        }

        public async Task<HttpResponseMessage> UpdatePurchaseOrder(PurchaseOrderVM po)
        {
            var purchaseOrder = new PurchaseOrder()
            {
                Code = po.DocNo,
                DocDate = po.DocDate,
                VCode = po.VendorCode,
                TotQuant = po.TotalQty,
                TotAmt = po.TotalAmt,
                Comment = po.Comment,
                Remarks = po.Remarks
            };

            var response = await _httpClient.PutAsJsonAsync($"/api/PurchaseOrders/{po.DocNo}", purchaseOrder);
            
            if (response.IsSuccessStatusCode)
            {
                foreach (var row in po.PO_Items)
                {
                    PO_Item poItem = new PO_Item()
                    {
                        ICode = row.ItemCode,
                        POCode = row.POCode,
                        IUnit = row.Unit,
                        Quantity = row.Quantity,
                        IRate = row.Rate,
                        Amount = row.Amount
                    };
                    // Save the PO_Items to the database
                    var poItemsResponse = await _httpClient.PostAsJsonAsync("/api/PO_Item", poItem);
                    if (!poItemsResponse.IsSuccessStatusCode)
                    {
                        // Handle error response
                        return poItemsResponse;
                    }
                }
            }

            return response;
        }
    }
}
