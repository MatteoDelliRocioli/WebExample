using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Data
{
    public class DataAccess : IDataAccess
    {
        private string _connectionString { get; set; }

        public DataAccess(IConfiguration config)
        {
            this._connectionString = config.GetConnectionString("cs");
        }

        public IEnumerable<Product> GetProducts()
        {
            /*var temp = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(new Product
                {
                    ProductID = i,
                    Name = $"Prodotto {i}"
                });
            }
            return temp;*/
            // eseguiamo una query per estrarre un recordset di prodotti
            var querySelect = @"
                    SELECT [ProductID] as Id
                          ,[Name]
                          ,[ProductNumber] as Code
                          ,[Color]
                          ,[Weight]
                          ,[ListPrice]
                          ,[SellStartDate]
                      FROM [SalesLT].[Product]";
            using (var connection = new SqlConnection(_connectionString))
            {
                var products = connection.Query<Product>(querySelect);
                return products.ToArray();
            }
        }

        public Product GetProductById(int id)
        {
            var querySelectById = @"
                    SELECT [ProductID] as Id
                          ,[Name]
                          ,[ProductNumber] as Code
                          ,[Color]
                          ,[Weight]
                          ,[ListPrice]
                          ,[SellStartDate]
                      FROM [SalesLT].[Product] 
                    WHERE ProductID = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                var product = connection.QueryFirstOrDefault<Product>(querySelectById, 
                    new {id});
                return product;
            }
        }
    }
}
