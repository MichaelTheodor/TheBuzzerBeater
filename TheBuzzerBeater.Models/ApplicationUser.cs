using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBuzzerBeater.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string? StreetAddress { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PostalCode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string? State { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Country { get; set; }
    }
}
