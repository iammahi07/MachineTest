using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineTest.Models
{
    public class Category
    {
        [Key]
        [DisplayName("CategoryId")]
        public int Id { get; set; }
        [Required]
        [DisplayName("CategoryName")]
        public string Name { get; set; }
    }
}
