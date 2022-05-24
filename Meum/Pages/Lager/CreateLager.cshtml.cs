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
    public class CreateLagerModel : PageModel
    {
        private ILagerDB _lagerService;

        [BindProperty]
        public MeumLibrary.Model.Lager Lager { get; set; }

        public CreateLagerModel(ILagerDB lagerService)
        {
            _lagerService = lagerService;
        }
        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            Lager = new MeumLibrary.Model.Lager();
        }

        public IActionResult OnPost()
        {
            _lagerService.Create(Lager);
            return Redirect("/Lager/Lager");
        }
    }
}
