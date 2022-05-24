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
    public class DeleteCustomerModel : PageModel
    {
        private IKundeDB _kundeService;

        public DeleteCustomerModel(IKundeDB kundeService)
        {
            _kundeService = kundeService;
        }

        [BindProperty]
        public Kunde kunde{ get; set; }


        public void OnGet(int id)
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            kunde = _kundeService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            Kunde deletedKunde = _kundeService.Delete(id);
            return Redirect("/Customers/Customer");
        }
    }
}
