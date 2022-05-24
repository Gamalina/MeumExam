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
    public class EditProductModel : PageModel
    {
        private IProduktDB _productService;

        public EditProductModel(IProduktDB productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Produkt Produkt { get; set; }

        public string ErrorMessage { get; private set; }
        public void OnGet(int id)
        {

            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            ErrorMessage = "";
            try
            {
                Produkt = _productService.GetByID(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"Et Produkt med det id findes ikke.";
            }
        }

        public IActionResult OnPost(int id)
        {
            
            Produkt.Id = id;
            _productService.Modify(Produkt);

            return RedirectToPage("/Product/Products");
        }
    }
}
