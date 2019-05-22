using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? StandardCost { get; set; }
        public DateTime SellStartDate { get; set; }

        public Product()
        { }

        public Product( string name, string productNumber, decimal? listPrice, decimal? standardCost, DateTime sellStartDate)
        {
            Name = name;
            ProductNumber = productNumber;
            ListPrice = listPrice;
            StandardCost = standardCost;
            SellStartDate = sellStartDate;
        }

        public Product(string name)
        {
            Name = name;
        }
    }
}
