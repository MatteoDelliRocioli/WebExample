using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Single Customer Detail object
        /// </summary>
        public Customer _customer { get; set; }

        private ICustomersDataAccess _data;

        public DetailsModel(ICustomersDataAccess data)
        {
            _data = data;
        }
        public void OnGet(int id)
        {
            _customer = this._data.GetCustomerById(id);
        }
    }
}