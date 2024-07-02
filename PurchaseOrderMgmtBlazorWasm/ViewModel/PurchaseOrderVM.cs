namespace PurchaseOrderMgmtBlazorWasm.ViewModel
{
    public class PurchaseOrderVM
    {
        // PurchaseOrder Table fields
        public string DocNo { get; set; } // Code
        public DateOnly DocDate { get; set; } // DocDate
        public string VendorCode { get; set; } // VCode
        public int TotalQty { get; set; }   // TotQuant
        public int TotalAmt { get; set; }   // TotAmt
        public string Comment { get; set; } // Comment
        public string Remarks { get; set; }  // Remarks

        public List<Row> PO_Items { get; set; }

        // Constructor to initialize PO_Items
        public PurchaseOrderVM()
        {
            PO_Items = new List<Row>();
        }
    }

    public class Row
    {
        public int SNo { get; set; } = 1;
        public string ItemCode { get; set; }
        public string POCode { get; set; }   // POCode
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int Amount { get; set; }
    }
}
