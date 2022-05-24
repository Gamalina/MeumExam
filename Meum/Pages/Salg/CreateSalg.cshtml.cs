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
    public class CreateSalgModel : PageModel
    {
        private ISalgDB _salgService;
        [BindProperty]
        public MeumLibrary.Model.Salg Salg { get; set; }

        public CreateSalgModel(ISalgDB salgService)
        {
            _salgService = salgService;
        }

        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            Salg = new MeumLibrary.Model.Salg();
        }

        public IActionResult OnPost()
        {
            _salgService.Create(Salg);
            return Redirect("/Salg/SalgListe");
        }
    }
}
