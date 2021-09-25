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
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.ProductS WHERE Id = @Id";

            //open connection to SQL db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    //execute scaler returns value of first column of whatever was updated
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
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

        //searching by product number
        public ProductModel GetProductByID(int id)
        {
            ProductModel foundProduct = null;
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";

            //open connection to SQL db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                //wild card for extra characters before and after search term and it will still match (partial search)
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = (new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            //open connection to SQL db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                //wild card for extra characters before and after search term and it will still match (partial search)
                command.Parameters.AddWithValue("@Name", '%'+ searchTerm + '%');

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

            //open connection to SQL db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                //wild card for extra characters before and after search term and it will still match (partial search)
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                try
                {
                    //execute scaler returns value of first column of whatever was updated
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

    }
}

