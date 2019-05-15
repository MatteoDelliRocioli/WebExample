﻿using System;
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
        //DONE: scegliere tabella, obiettivo-> index deve farmi vedere l'elenco di oggetti; la pagina di dettaglio-> query solo con quell'evento dati solo di quel prodotto 

        //TODO: Fare inserimento e poi fare modifica

        public string CurrentDate { get; set; }
        public IEnumerable<Product> List { get; set; }

        private IProductsDataAccess _data;

        public IndexModel(IProductsDataAccess data)
        {
            _data = data;
        }

        public void OnGet() //richiesta visualizzazione pagina
        {
            CurrentDate = DateTime.Now.ToShortDateString();
            List = this._data.GetProducts();
        }

        public void OnPost() //fa riferimento anche a put e delete ma a livello API
        {

        }
    }
}
