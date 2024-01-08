using System.ComponentModel.DataAnnotations;

namespace E_CommerceShop_TheBuzzerBeater.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
