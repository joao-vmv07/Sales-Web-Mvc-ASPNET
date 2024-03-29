﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Services;
namespace SalesWebMVC.Controllers
{
    
    public class SalesRecordsController : Controller
    {
        private readonly SaleRecordsServices _salesRecordsService;

        public SalesRecordsController(SaleRecordsServices salerecords)
        {
            _salesRecordsService = salerecords;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime ? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                minDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy/MM/dd");
            ViewData["maxDate"] = minDate.Value.ToString("yyyy/MM/dd");

            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                minDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy/MM/dd");
            ViewData["maxDate"] = minDate.Value.ToString("yyyy/MM/dd");

            var result = await _salesRecordsService.FindByDateGroupAsync(minDate, maxDate);
            return View(result);
            
        }

    }
}
