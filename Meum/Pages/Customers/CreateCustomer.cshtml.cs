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

namespace Meum.Pages.Customers
{
    public class CreateCustomerModel : PageModel
    {
        private IKundeDB _kundeService;

        [BindProperty]
        public Kunde kunde { get; set; }

        public string ErrorMessage { get; private set; }

        public CreateCustomerModel(IKundeDB kundeService)
        {
            _kundeService = kundeService;
        }

        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            kunde = new Kunde();
        }

        public IActionResult OnPost()
        {
            

            _kundeService.Create(kunde);
            return Redirect("/Customers/Customer");
        }
    }
}
