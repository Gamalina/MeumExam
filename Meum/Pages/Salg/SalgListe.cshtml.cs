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

namespace Meum.Pages.Salg
{
    public class SalgListeModel : PageModel
    {
        private ISalgDB _salgService;

        private static List<MeumLibrary.Model.Salg> _originalListe;

        public List<MeumLibrary.Model.Salg> Salgs { get; private set; }

        public SalgListeModel(ISalgDB salgService)
        {
            _salgService = salgService;
        }

        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            _originalListe = _salgService.GetAll();
            Salgs = new List<MeumLibrary.Model.Salg>(_originalListe);
        }
    }
}
