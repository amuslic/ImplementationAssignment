using System;
using System.ComponentModel.DataAnnotations;

namespace ImplementationAssignment.Models
{
    public class SaleData
    {
        [Key]
        public Guid SaleDataId { get; set; }
        [StringLength(32, ErrorMessage = "Name cannot exceed 32 characters")]
        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
