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
    public class CreateProductModel : PageModel
    {
        private IProduktDB _produktService;
        
        [BindProperty]
        public Produkt Produkt { get; set; }

        public CreateProductModel(IProduktDB produktService)
        {
            _produktService = produktService;
        }
        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            Produkt = new Produkt();
        }

        public IActionResult OnPost()
        {
            _produktService.Create(Produkt);
            return Redirect("/Product/Products");
        }
    }
}
