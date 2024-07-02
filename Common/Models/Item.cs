using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Item
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Rate { get; set; }
    }
}
