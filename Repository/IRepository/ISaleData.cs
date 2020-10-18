using ImplementationAssignment.Models;
using ImplementationAssignment.Models.DTO;
using System;
using System.Collections.Generic;

namespace ImplementationAssignment.Repository.IRepository
{
    public interface ISaleData
    {
        SaleData GetSaleDataById(Guid id);
        bool CreateSaleData(SaleData saleData);      
        ICollection<NumOfSoldItemsPerDayDTO> GetNumberOfSoldItemsPerDays();
        ICollection<NumOfSoldItemsPerDayDTO> GetNumberOfSoldItemsPerDay(string day);
        bool Save();
    }
}
