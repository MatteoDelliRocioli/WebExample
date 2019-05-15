﻿using System;
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
        public Product _product { get; set; }

        private readonly IProductsDataAccess _data;

        public DetailsModel(IProductsDataAccess data)
        {
            _data = data;
        }

        public void OnGet(int id)
        {
            _product = this._data.GetProductById(id);
        }
    }
}