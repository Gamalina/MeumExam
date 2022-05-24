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
    public class EditCustomerModel : PageModel
    {
        private IKundeDB _kundeService;

        public EditCustomerModel(IKundeDB kundeService)
        {
            _kundeService = kundeService;
        }

        [BindProperty]
        public Kunde kunde { get; set; }

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
                kunde = _kundeService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"En kunde med det id findes ikke.";
            }
        }

        public IActionResult OnPost(int id)
        {
            kunde.Id = id;
            _kundeService.Modify(kunde);

            return RedirectToPage("/Customers/Customer");
        }
    }
}
