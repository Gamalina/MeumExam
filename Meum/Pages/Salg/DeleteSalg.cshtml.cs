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
    public class DeleteSalgModel : PageModel
    {
        private ISalgDB _salgService;

        public DeleteSalgModel(ISalgDB salgService)
        {
            _salgService = salgService;
        }
        [BindProperty]
        public MeumLibrary.Model.Salg Salg { get; set; }
        public void OnGet(int id)
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            Salg = _salgService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            MeumLibrary.Model.Salg deletedSalg = _salgService.Delete(id);
            return Redirect("/Salg/SalgListe");
        }
    }
}
