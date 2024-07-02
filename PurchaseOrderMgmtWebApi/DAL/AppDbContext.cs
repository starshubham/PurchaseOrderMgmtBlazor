using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace PurchaseOrderMgmtWebApi.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> ITEM_MASTER { get; set; }
        public DbSet<PO_Item> PO_Item { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set;}
        public DbSet<Vendor> Vendor_MASTER { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PO_Item>()
        //        .HasOne(p => p.PurchaseOrder)
        //        .WithMany(b => b.PO_Items)
        //        .HasForeignKey(p => p.POCode)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }
}
