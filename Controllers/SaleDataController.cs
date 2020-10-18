using System;
using System.Collections.Generic;
using AutoMapper;
using ImplementationAssignment.Models;
using ImplementationAssignment.Models.DTO;
using ImplementationAssignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ImplementationAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public class SaleDataController : ControllerBase
    {
        private readonly ISaleData _saleData;
        private readonly IMapper _mapper;
        public SaleDataController(ISaleData saleData, IMapper mapper)
        {
            _saleData = saleData;
            _mapper = mapper;
        }
        /// <summary>
        /// Get sale data by Id
        /// </summary>
        /// <param name="saleDataId">Id of the sale data we want</param>
        /// <returns></returns>
        [HttpGet("GetSaleDataById/{saleDataId}", Name = "GetSaleDataById")]
        [ProducesResponseType(200, Type = typeof(SaleDataDTO))]
        [ProducesDefaultResponseType]
        public IActionResult GetSaleDataById(Guid saleDataId)
        {
            var saleData = _saleData.GetSaleDataById(saleDataId);
            if (saleData == null)
            {
                return NotFound();
            }
            var saleDataDTO = _mapper.Map<SaleDataDTO>(saleData);
            return Ok(saleDataDTO);
        }
        /// <summary>
        /// Create sale data
        /// </summary>
        /// <param name="saleDataDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateSaleData")]
        [ProducesResponseType(201, Type = typeof(SaleDataDTO))]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]
        public IActionResult CreateSaleData([FromBody] SaleDataDTO saleDataDTO)
        {
            if (saleDataDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (saleDataDTO.ArticleNumber.Length > 32)
            {
                ModelState.AddModelError("", $"Article name cannot exceed 32 charachters");
                return BadRequest(ModelState);
            }

            var saleDataobj = _mapper.Map<SaleData>(saleDataDTO);

            if (!_saleData.CreateSaleData(saleDataobj))
            {
                ModelState.AddModelError("", $"Something went wrong when creating data {saleDataDTO.ArticleNumber}");
                return StatusCode(500);
            }
            else
            {
                return CreatedAtRoute("GetSaleDataById",
                    new { saleDataId = saleDataobj.SaleDataId }, saleDataobj);
            }
        }
        /// <summary>
        /// Get number of sold articles per days
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNumberOfSoldArticlesPerDays")]
        [ProducesResponseType(200, Type = typeof(List<NumOfSoldItemsPerDayDTO>))]
        [ProducesDefaultResponseType]
        public IActionResult GetNumberOfSoldArticlesPerDays()
        {
            var obj = _saleData.GetNumberOfSoldItemsPerDays();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        /// <summary>
        /// Get number of sold articles per day
        /// </summary>
        /// <param name="day">Day in a week from which we want to see number of sold articles</param>
        /// <returns></returns>
        [HttpGet("GetNumberOfSoldArticlesPerDay/{day}")]
        [ProducesResponseType(200, Type = typeof(List<NumOfSoldItemsPerDayDTO>))]       
        [ProducesDefaultResponseType]
        public IActionResult GetNumberOfSoldArticlesPerDay(string day)
        {
            var obj = _saleData.GetNumberOfSoldItemsPerDay(day);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
