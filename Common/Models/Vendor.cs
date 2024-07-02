using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Vendor
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
