using Bogus;
using Display_Data_in_a_Table.Models;
using Display_Data_in_a_Table.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Display_Data_in_a_Table.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();

            return View(hardCodedSampleDataRepository.GetAllProducts());
        }
    }
}
