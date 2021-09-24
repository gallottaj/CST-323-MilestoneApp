using Display_Data_in_a_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//interface is used to create an outline of what other classes will be used
//write the "contract" for what other items should do
namespace Display_Data_in_a_Table.Services
{
    interface IProductDataService
    {
        //all of the functions that a typical CRUD app has to do
        List<ProductModel> GetAllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductByID(int id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);
    }
}
