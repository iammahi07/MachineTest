using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MachineTest.Models
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DisplayName("ProductId")]
        public int Id { get; set; }
        [DisplayName("ProductName")]
        public string Name { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
