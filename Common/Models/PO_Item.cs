using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class PO_Item
    {
        [Key]
        public int Id { get; set; }
        public string ICode { get; set; }
        public string POCode { get; set; }
        public string IUnit { get; set; }
        public int Quantity { get; set; }
        public int IRate { get; set; }
        public int Amount { get; set; }
        //[JsonIgnore]
        //public PurchaseOrder PurchaseOrder { get; set; }  // Navigation property
    }
}
