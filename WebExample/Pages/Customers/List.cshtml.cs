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
    public class ListModel : PageModel
    {
        private ICustomersDataAccess _dataAccess;

        public IEnumerable<Customer> _customers { get; set; }

        public ListModel(ICustomersDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void OnGet()
        {
            _customers = _dataAccess.GetAllCustomers();
        }
    }
}