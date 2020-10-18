using ImplementationAssignment.Data;
using ImplementationAssignment.Models;
using ImplementationAssignment.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationAssignment.Repository
{
    public class RevenueRepository : IRevenue
    {
        private readonly ApplicationDbContext _db;
        public RevenueRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<NumOfSoldItemsPerDayRevenueDTO> GetTotalRevenuePerDays()
        {
            var totalRevenuePerDays = from numOfSoldItemsPerDay in _db.numOfSoldItemsPerDay
                                      join days in _db.daysInAWeek on numOfSoldItemsPerDay.DayId equals days.DayId
                                      join salesData in _db.saleDatas on numOfSoldItemsPerDay.SaleDataId equals salesData.SaleDataId
                                      group new { numOfSoldItemsPerDay, days, salesData } by new { days.DayName } into grouped
                                      select new NumOfSoldItemsPerDayRevenueDTO
                                      {
                                          Revenue = grouped.Where(g => g.salesData.SaleDataId == g.numOfSoldItemsPerDay.SaleDataId).
                                          Sum(g => g.numOfSoldItemsPerDay.NumOfItemsSold * g.salesData.SalesPrice),
                                          Day = grouped.Key.DayName
                                      };
            return totalRevenuePerDays.ToList();
        }
        public ICollection<NumOfSoldItemsPerDayRevenueDTO> GetTotalRevenuePerDay(string day)
        {
            var totalRevenuePerDays = from numOfSoldItemsPerDay in _db.numOfSoldItemsPerDay
                                      join days in _db.daysInAWeek on numOfSoldItemsPerDay.DayId equals days.DayId
                                      join salesData in _db.saleDatas on numOfSoldItemsPerDay.SaleDataId equals salesData.SaleDataId
                                      group new { numOfSoldItemsPerDay, days, salesData } by new { days.DayName } into grouped
                                      select new NumOfSoldItemsPerDayRevenueDTO
                                      {
                                          Revenue = grouped.Where(g => g.salesData.SaleDataId == g.numOfSoldItemsPerDay.SaleDataId).
                                          Sum(g => g.numOfSoldItemsPerDay.NumOfItemsSold * g.salesData.SalesPrice),
                                          Day = grouped.Key.DayName
                                      };
            return totalRevenuePerDays.Where(trpd => trpd.Day == day).ToList();
        }

        public ICollection<NumberOfSoldItemsGroupedDTO> GetRevenueGroupedByArticle()
        {
            var totalRevenuePerDays = from numOfSoldItemsPerDay in _db.numOfSoldItemsPerDay
                                      join salesData in _db.saleDatas on numOfSoldItemsPerDay.SaleDataId equals salesData.SaleDataId
                                      group new { numOfSoldItemsPerDay, salesData } by new { salesData.ArticleNumber } into grouped
                                      select new NumberOfSoldItemsGroupedDTO
                                      {
                                          ArticleName = grouped.Key.ArticleNumber,
                                          Revenue = grouped.Where(g => g.salesData.SaleDataId == g.numOfSoldItemsPerDay.SaleDataId).
                                          Sum(g => g.numOfSoldItemsPerDay.NumOfItemsSold * g.salesData.SalesPrice),
                                      };


            return totalRevenuePerDays.ToList();

        }
    }
}


