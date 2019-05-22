using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Models;
using static WebExample.Pages.Products.ModifyModel;

namespace WebExample.Data
{
    public interface IProductsDataAccess
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void InsertProduct(Product product);
        void ModifyProduct(ProductModifyInput product);
    }
}
