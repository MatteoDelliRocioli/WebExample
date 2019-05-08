using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
            var temp = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(new Product
                {
                    Id = i,
                    Name = $"Prodotto {i}"
                });
            }
            return temp;
        }
    }
}
