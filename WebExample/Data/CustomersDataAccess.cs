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
    public class CustomersDataAccess : ICustomersDataAccess
    {
        private string _connectionString { get; set; }

        public CustomersDataAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("cs");
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            var querySelect = @"SELECT[CustomerID] as id
                                      ,[NameStyle]
                                      ,[Title]
                                      ,[FirstName]
                                      ,[MiddleName]
                                      ,[LastName]
                                      ,[Suffix]
                                      ,[CompanyName]
                                      ,[SalesPerson]
                                      ,[EmailAddress]
                                      ,[Phone]
                                      ,[PasswordHash]
                                      ,[PasswordSalt]
                                      ,[rowguid]
                                      ,[ModifiedDate]
                                  FROM[AdventureWorksLT2017].[SalesLT].[Customer]";
            using (var connection = new SqlConnection(_connectionString))
            {
                var customers = connection.Query<Customer>(querySelect);
                return customers.ToArray();
            }
        }

        public Customer GetCustomerById(int id)
        {
            var querySelectById = @"SELECT[CustomerID] as id
                                      ,[NameStyle]
                                      ,[Title]
                                      ,[FirstName]
                                      ,[MiddleName]
                                      ,[LastName]
                                      ,[Suffix]
                                      ,[CompanyName]
                                      ,[SalesPerson]
                                      ,[EmailAddress]
                                      ,[Phone]
                                      ,[PasswordHash]
                                      ,[PasswordSalt]
                                      ,[rowguid]
                                      ,[ModifiedDate]
                                  FROM[AdventureWorksLT2017].[SalesLT].[Customer]
                                    WHERE CustomerID = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var customer = connection.QueryFirstOrDefault<Customer>(querySelectById, new { id });
                return customer;
            }
        }
    }
}
