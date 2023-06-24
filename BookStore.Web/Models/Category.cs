using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Web.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Quantity is required"), DisplayName("Quantity"), Range(1,1000, ErrorMessage ="Quantity should be between 1 and 1000")]
        public int DiplayOrder { get; set; }
        [Required(ErrorMessage ="Date is required"), DisplayName("Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
