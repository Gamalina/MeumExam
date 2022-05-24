using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meum.Pages.Login;
using Meum.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meum.Pages.Lager
{
    public class LagerModel : PageModel
    {
        private ILagerDB _lagerService;

        private static List<MeumLibrary.Model.Lager> _originalListe;

        public List<MeumLibrary.Model.Lager> Lagers { get; private set; }

        public LagerModel(ILagerDB lagerService)
        {
            _lagerService = lagerService;
        }
        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            _originalListe = _lagerService.GetAll();
            Lagers = new List<MeumLibrary.Model.Lager>(_originalListe);

        }
    }
}
