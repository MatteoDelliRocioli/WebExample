using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Data
{
    public interface ICustomersDataAccess
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
    }
}
