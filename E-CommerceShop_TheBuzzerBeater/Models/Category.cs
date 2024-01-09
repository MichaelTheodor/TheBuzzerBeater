using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceShop_TheBuzzerBeater.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,150,ErrorMessage ="Display Order must be between 1-150")]
        public int DisplayOrder { get; set; }
    }
}
