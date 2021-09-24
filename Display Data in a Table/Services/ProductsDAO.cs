using Display_Data_in_a_Table.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Display_Data_in_a_Table.Services
{
    public class ProductsDAO : IProductDataService
    {
        //sql connection string to test db
        //@ tells system that all ' are literall
        string connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products";

            //open connection to SQL db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3]});
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
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
