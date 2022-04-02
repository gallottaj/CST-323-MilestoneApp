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
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {
        //define requests
        [HttpGet]
        public ActionResult<IEnumerable<ProductModelDTO>> Index()
        {
            //fetch all products from db
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = products.GetAllProducts();
            
            List<ProductModelDTO> productDTOs = new List<ProductModelDTO>();
            //translate list of objects
            foreach (var p in productList)
            {
                productDTOs.Add(new ProductModelDTO(p));
            }

            return productDTOs;
        }

        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchProducts(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            return products.SearchProducts(searchTerm);
        }

        [HttpGet("showoneproduct/{Id}")]
        public ActionResult<ProductModelDTO> ShowOneProduct(int Id)
        {
            ProductsDAO products = new ProductsDAO();

            ProductModel p = products.GetProductByID(Id);

            ProductModelDTO pDTO = new ProductModelDTO(p);

            return pDTO;
        }
        /*        public IActionResult Edit(int id)
                {
                    ProductsDAO products = new ProductsDAO();
                    ProductModel foundProduct = products.GetProductByID(id);
                    return View("ShowEdit", foundProduct);
                }*/

        [HttpPut("processedit")]
        public ActionResult<IEnumerable<ProductModel>> ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return products.GetAllProducts();
        }

        [HttpPut("ProcessEditReturnOneItem")]
        public ActionResult<ProductModel> ProcessEditReturnOneItem(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();

            products.Update(product);
            return products.GetProductByID(product.Id);
        }
    }
}

/*        public IActionResult SearchForm()
        {
            return View();
        }*/
