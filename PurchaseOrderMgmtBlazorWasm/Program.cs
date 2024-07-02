using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PurchaseOrderMgmtBlazorWasm;
using PurchaseOrderMgmtBlazorWasm.Services;
using PurchaseOrderMgmtBlazorWasm.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7120/") });
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IItemService, ItemService>();

await builder.Build().RunAsync();
