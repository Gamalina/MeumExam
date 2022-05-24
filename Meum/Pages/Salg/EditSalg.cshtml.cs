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
    public class EditSalgModel : PageModel
    {
        private ISalgDB _salgService;

        public EditSalgModel(ISalgDB salgService)
        {
            _salgService = salgService;
        }
        [BindProperty]
        public MeumLibrary.Model.Salg Salg { get; set; }

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
                Salg = _salgService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"Et abonnoment med det id findes ikke.";
            }
        }

        public IActionResult OnPost(int id)
        {
            Salg.Id = id;
            _salgService.Modify(Salg);

            return Redirect("/Salg/SalgListe");
        }
    }
}
