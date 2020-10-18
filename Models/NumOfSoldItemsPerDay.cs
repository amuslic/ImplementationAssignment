using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationAssignment.Models
{
    public class NumOfSoldItemsPerDay
    {
        [Key]
        public int Id { get; set; }
        public Guid SaleDataId { get; set; }
        public int DayId { get; set; }
        public int NumOfItemsSold { get; set; }
    }
}
