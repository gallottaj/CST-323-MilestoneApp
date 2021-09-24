using Display_Data_in_a_Table.Models;
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
            List<ProductModel> productsList = new List<ProductModel>();
            productsList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "A square piece of fabric to make the mouse move easier" });
            productsList.Add(new ProductModel { Id = 2, Name = "Webcam", Price = 45.99m, Description = "Enables you to attend more Zoom meetings." });
            productsList.Add(new ProductModel { Id = 3, Name = "USB hard drive", Price = 56.99m, Description = "Use to back up all of your work" });
            productsList.Add(new ProductModel { Id = 4, Name = "Wireless mouse", Price = 23.98m, Description = "An external mouse" });

            return View(productsList);
        }
    }
}
