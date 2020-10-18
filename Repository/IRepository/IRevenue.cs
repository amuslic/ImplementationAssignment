using ImplementationAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationAssignment.Repository.IRepository
{
    public interface IRevenue
    {
        ICollection<NumOfSoldItemsPerDayRevenueDTO> GetTotalRevenuePerDay(string day);
        ICollection<NumOfSoldItemsPerDayRevenueDTO> GetTotalRevenuePerDays();
        ICollection<NumberOfSoldItemsGroupedDTO> GetRevenueGroupedByArticle();
    }
}
