using ImplementationAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<SaleData> saleDatas { get; set; }
        public DbSet<DaysInAWeek> daysInAWeek { get; set; }
        public DbSet<NumOfSoldItemsPerDay> numOfSoldItemsPerDay { get; set; }
    }
}
