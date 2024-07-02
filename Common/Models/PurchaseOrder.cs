using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class PurchaseOrder
    {
        [Key]
        public string Code { get; set; }
        public DateOnly DocDate { get; set; }
        public string VCode { get; set; }
        public int TotQuant { get; set; }
        public int TotAmt { get; set; }
        public string Comment { get; set; }
        public string Remarks { get; set; }
        //[JsonIgnore]
        //public ICollection<PO_Item> PO_Items { get; set; }  // Navigation property
    }
}
