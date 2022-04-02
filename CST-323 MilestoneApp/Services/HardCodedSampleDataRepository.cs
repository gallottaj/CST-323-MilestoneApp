using Bogus;
using Display_Data_in_a_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Display_Data_in_a_Table.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        //class member variable
        //generates static list
        static List<ProductModel> productsList = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if (productsList.Count == 0)
            {
                productsList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "A square piece of fabric to make the mouse move easier" });
                productsList.Add(new ProductModel { Id = 2, Name = "Webcam", Price = 45.99m, Description = "Enables you to attend more Zoom meetings." });
                productsList.Add(new ProductModel { Id = 3, Name = "USB hard drive", Price = 56.99m, Description = "Use to back up all of your work" });
                productsList.Add(new ProductModel { Id = 4, Name = "Wireless mouse", Price = 23.98m, Description = "An external mouse" });

                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>().RuleFor(p => p.Id, i + 5).RuleFor(p => p.Name, f => f.Commerce.ProductName()).RuleFor(p => p.Price, f => f.Random.Decimal(100)).RuleFor(p => p.Description, f => f.Rant.Review()));
                }
            }

            return productsList;
        }

        public ProductModel GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
