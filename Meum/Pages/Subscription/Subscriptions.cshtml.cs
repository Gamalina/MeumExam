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

namespace Meum.Pages.Subcription
{
    public class SubscriptionsModel : PageModel
    {
        private IAbonnomentDB _abonnomentService;
        private static List<Abonnoment> _originalListe;
        public List<Abonnoment> Abonnoments { get; private set; }

        public SubscriptionsModel(IAbonnomentDB abonnomentService)
        {
            _abonnomentService = abonnomentService;
        }
        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            _originalListe = _abonnomentService.GetAll();
            Abonnoments = new List<Abonnoment>(_originalListe);
        }
    }
}
