using ADO_NET_Fundamentals.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Fundamentals
{
    public class CRUDOperations
    {
        private readonly string _connectionString;

        public CRUDOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAllProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Products", connection);
                var reader = command.ExecuteReader();
                var products = new List<Product>();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    };
                    products.Add(product);
                }
                return products;
            }
        }


        public List<Order> GetOrdersByMonth(int month, int year)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("GetOrdersByMonth", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                var reader = command.ExecuteReader();
                var orders = new List<Order>();
                while (reader.Read())
                {
                    var order = new Order
                    {
                        Id = (int)reader["Id"],
                        Date = (DateTime)reader["Date"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        TotalPrice = (decimal)reader["TotalPrice"],
                        Status = (string)reader["Status"]
                    };
                    orders.Add(order);
                }
                return orders;
            }
        }

        public List<Order> GetOrdersByProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("GetOrdersByProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Product", product);
                var reader = command.ExecuteReader();
                var orders = new List<Order>();
                while (reader.Read())
                {
                    var order = new Order
                    {
                        Id = (int)reader["Id"],
                        Date = (DateTime)reader["Date"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        TotalPrice = (decimal)reader["TotalPrice"],
                        Status = (string)reader["Status"]
                    };
                    orders.Add(order);
                }
                return orders;
            }
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)", connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
        }

        public void AddOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Orders (Date, Quantity, TotalPrice, Status) VALUES (@Date, @Quantity, @TotalPrice, @Status)", connection);
                command.Parameters.AddWithValue("@Date", order.Date);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Products SET Name=@Name, Price=@Price, Quantity=@Quantity WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Orders SET Date=@Date, Quantity=@Quantity, TotalPrice=@TotalPrice, Status=@Status WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@Id", order.Id);
                command.Parameters.AddWithValue("@Date", order.Date);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrdersByProduct(int productId, int month, int year, string status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DeleteOrdersByProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@Status", status);
                command.ExecuteNonQuery();
            }
        }
    }
}
