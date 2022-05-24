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
    public class UpdateLagerModel : PageModel
    {
        private ILagerDB _lagerService;

        public UpdateLagerModel(ILagerDB lagerService)
        {
            _lagerService = lagerService;
        }

        [BindProperty]
        public MeumLibrary.Model.Lager Lager { get; set; }

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
                Lager = _lagerService.GetByID(id);
            }
            catch (KeyNotFoundException ex )
            {
                ErrorMessage = $"Et produkt med det id findes ikke.";
            }
        }

        public IActionResult OnPost(int id)
        {
            Lager.Id = id;
            _lagerService.Modify(Lager);

            return RedirectToPage("/Lager/Lager");
        }
    }
}
