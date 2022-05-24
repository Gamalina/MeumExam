using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meum.Pages.Login;
using Meum.Services;
using MeumLibrary.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meum.Pages.Product
{
    public class ProductsModel : PageModel
    {
        private IProduktDB _produktService;

        private static List<Produkt> _originalListe;

        public List<Produkt> Produkts { get; private set; }

        public ProductsModel(IProduktDB produktService)
        {
            _produktService = produktService;
        }

        public void OnGet()
        {
            


            _originalListe = _produktService.GetAll();
            Produkts = new List<Produkt>(_originalListe);
        }
    }
}
