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
    [IgnoreAntiforgeryToken] //altra soluzione lo vado a recuperare e inserire nell'oggetto di cui faccio la Post
    public class InsertModel : PageModel
    {
        private readonly IProductsDataAccess _data;

        [BindProperty] //invece del parametro dentro le api
        public ProductInsertInput Input { get; set; }

        public InsertModel(IProductsDataAccess data)
        {
            _data = data;
        }

        public class ProductInsertInput
        {
            [Display(Name ="Codice")]
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

        public void OnGet()
        {
            Input = new ProductInsertInput();
        }

        public IActionResult OnPost()
        {
            if (Input.Code == "123") //comparirà solamente nel validation summary
            {
                ModelState.AddModelError("Input.Code", "Il codice non può essere 123.");  // nel momento in cui specifichi la key l'erroe verrà visualizzato anche accanto al campo
                //se string key vouta-> compariranno sul summary
            }

            if (ModelState.IsValid)
            {
                //salvo su db
                var product = new Product(Input.Name, Input.Code, Input.Price, Input.StandardCost, Input.SellStartDate);
                _data.InsertProduct(product);
                return RedirectToPage("/Index");
            }

            return Page(); //ritorna l'html della pagina corrente
        }

        public IActionResult OnPostGetMessage() //OnPost + Handler (da chiamare dentro  html.tag.asp-page-handler="Message")
        {
            return new JsonResult(new
            {
                JsonResult = true,

                Message = $"Ciao, sono le ore {DateTime.Now.ToShortTimeString()}"
            });
        }

        public IActionResult OnPostSubscribe(string mail)
        {
            return RedirectToPage("Insert"); //rientro nella pagina insert passando dal get (pagina nuova)
        }
    }
}