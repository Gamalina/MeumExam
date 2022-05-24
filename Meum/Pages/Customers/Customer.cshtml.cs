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
    public class CustomerModel : PageModel
    {

        private IKundeDB _kundeService;

        private static List<Kunde> _originalListe;

        public List<Kunde> Kunder { get; private set; }

        public CustomerModel(IKundeDB kundeService)
        {
            _kundeService = kundeService;
        }

        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            _originalListe = _kundeService.GetAll();
            Kunder = new List<Kunde>(_originalListe);
        }
    }
}
