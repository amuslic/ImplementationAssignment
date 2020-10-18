using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationAssignment.Models.DTO
{
    public class SaleDataDTO
    {
        [Required, StringLength(32, ErrorMessage = "Name cannot exceed 32 characters")]
        public string ArticleNumber { get; set; }
        [Required]
        public double? SalesPrice { get; set; }
    }
}
