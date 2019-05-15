using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Data
{
    public interface IProductsDataAccess
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}
