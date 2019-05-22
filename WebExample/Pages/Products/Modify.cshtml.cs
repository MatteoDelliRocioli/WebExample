using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Pages.Products
{
    public class ModifyModel : PageModel
    {
        public class ProductModifyInput
        {
            [Display(Name = "Id")]
            public int Id { get; set; }

            [Display(Name = "Codice")]
            [Required]
            [StringLength(6, MinimumLength = 3)]
            public string Code { get; set; }

            [Display(Name = "Nome")]
            [Required]
            [StringLength(250)]
            public string Name { get; set; }

            [Display(Name = "Prezzo")]
            [DataType(DataType.Currency)]
            public decimal? Price { get; set; }

            [Display(Name = "PrezzoStandard")]
            [DataType(DataType.Currency)]
            public decimal? StandardCost { get; set; }

            [Display(Name = "Prima data utile per l'acquisto")]
            [DataType(DataType.DateTime)]
            public DateTime SellStartDate { get; set; }
        }

        public ProductModifyInput _ModifyObject { get; set; }

        public Product _product { get; set; }

        public IProductsDataAccess _data { get; set; }

        public ModifyModel(IProductsDataAccess data)
        {
            _data = data;
        }

        public void OnGet(int id)
        {
            _product = this._data.GetProductById(id);
            _ModifyObject = new ProductModifyInput();
        }

        public IActionResult OnPost(int id)
        {
            //_product = this._data.GetProductById(id);
            var modifiedProduct = new Product(_ModifyObject.Name); //TODO: vedere col prof
            modifiedProduct.Id = id;
            _data.ModifyProduct(_ModifyObject);
            return RedirectToPage("/Index");
        }
    }
}