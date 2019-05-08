using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentDate { get; set; }
        public IEnumerable<Product> List { get; set; }

        private IDataAccess _data;

        public IndexModel(IDataAccess data)
        {
            _data = data;
        }

        public void OnGet() //richiesta visualizzazione pagina
        {
            CurrentDate = DateTime.Now.ToShortDateString();

            //var temp = new List<string>();
            //for (int i =0; i < 10; i++)
            //{
            //    temp.Add($"Prodotto {i}");
            //}
            //List = temp;

            /*var temp = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(new Product
                {
                    Id = i, 
                    Name = $"Prodotto {i}"
                });
            }
            List = temp;*/

            List = this._data.GetProducts();
        }

        public void OnPost() //fa riferimento anche a put e delete ma a livello API
        {

        }
    }
}
