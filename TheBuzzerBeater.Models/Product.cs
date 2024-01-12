using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TheBuzzerBeater.Models
{
    public class Product
    {

        [Key]
         public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [StringLength(1000)] 
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1,2000)] 
        public double Price { get; set; }

        
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        //[ValidateNever]
        public string ImageUrl { get; set; }
    }
}
