using ImplementationAssignment.Data;
using ImplementationAssignment.Models;
using ImplementationAssignment.Models.DTO;
using ImplementationAssignment.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationAssignment.Repository
{
    public class SaleDataRepository : ISaleData
    {
        private readonly ApplicationDbContext _db;
        public SaleData GetSaleDataById(Guid id)
        {
            return _db.saleDatas.Where(sd => sd.SaleDataId == id).FirstOrDefault();
        }
        public SaleDataRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateSaleData(SaleData saleData)
        {
            _db.saleDatas.Add(saleData);
            return Save();
        }
        public ICollection<NumOfSoldItemsPerDayDTO> GetNumberOfSoldItemsPerDays()
        {
            var numberOfSoldArticlesPerDay = from numOfSoldItemsPerDay in _db.numOfSoldItemsPerDay
                                             join days in _db.daysInAWeek on numOfSoldItemsPerDay.DayId equals days.DayId
                                             join salesData in _db.saleDatas on numOfSoldItemsPerDay.SaleDataId equals salesData.SaleDataId
                                             group new { numOfSoldItemsPerDay.NumOfItemsSold, days.DayName } by new { days.DayName } into groupedNumOfSoldItemsPerDays
                                             select new NumOfSoldItemsPerDayDTO
                                             {
                                                 ItemsSold = groupedNumOfSoldItemsPerDays.Sum(g => g.NumOfItemsSold),
                                                 Day = groupedNumOfSoldItemsPerDays.Key.DayName
                                             };
            return numberOfSoldArticlesPerDay.ToList();
        }
        public ICollection<NumOfSoldItemsPerDayDTO> GetNumberOfSoldItemsPerDay(string day)
        {
            var numberOfSoldArticlesPerDay = from numOfSoldItemsPerDay in _db.numOfSoldItemsPerDay
                                             join days in _db.daysInAWeek on numOfSoldItemsPerDay.DayId equals days.DayId
                                             join salesData in _db.saleDatas on numOfSoldItemsPerDay.SaleDataId equals salesData.SaleDataId
                                             group new { numOfSoldItemsPerDay.NumOfItemsSold, days.DayName } by new { days.DayName } into groupedNumOfSoldItemsPerDay
                                             select new NumOfSoldItemsPerDayDTO
                                             {
                                                 ItemsSold = groupedNumOfSoldItemsPerDay.Sum(g => g.NumOfItemsSold),
                                                 Day = groupedNumOfSoldItemsPerDay.Key.DayName
                                             };
            return numberOfSoldArticlesPerDay.Where(nosapd => nosapd.Day == day).ToList();
        }       
        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
