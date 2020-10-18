using ImplementationAssignment.Models;
using ImplementationAssignment.Models.DTO;
using ImplementationAssignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ImplementationAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ProducesResponseType(200, Type = typeof(List<NumOfSoldItemsPerDayRevenueDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    
    public class RevenueController : ControllerBase
    {
        private readonly IRevenue _revenue;
        public RevenueController(IRevenue revenue)
        {
            _revenue = revenue;
        }
        /// <summary>
        /// Get total revenue per days
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalRevenuePerDays")]
        [ProducesDefaultResponseType]
        public IActionResult GetTotalRevenuePerDays()
        {
            var obj = _revenue.GetTotalRevenuePerDays();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        /// <summary>
        /// Get total revenue per day
        /// </summary>
        /// <param name="day">Day in a week from which we want to see the revenue</param>
        /// <returns></returns>
        [HttpGet("GetTotalRevenuePerDay/{day}")]
        [ProducesDefaultResponseType]
        public IActionResult GetTotalRevenuePerDay(string day)
        {
            var obj = _revenue.GetTotalRevenuePerDay(day);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        /// <summary>
        /// Get revenue grouped by article
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRevenueGroupedByArticle")]
        [ProducesDefaultResponseType]
        public IActionResult GetRevenueGroupedByArticle()
        {
            var obj = _revenue.GetRevenueGroupedByArticle();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
