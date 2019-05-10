using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Pages.Products
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Single Product Detail object
        /// </summary>
        public Product product { get; set; }

        private IDataAccess _data;

        public DetailsModel(IDataAccess data)
        {
            _data = data;
        }

        public void OnGet(int id)
        {
            product = this._data.GetProductById(id);
        }
    }
}