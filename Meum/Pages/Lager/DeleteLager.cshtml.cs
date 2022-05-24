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
    public class DeleteLagerModel : PageModel
    {

        private ILagerDB _lagerService;

        public DeleteLagerModel(ILagerDB lagerService)
        {
            _lagerService = lagerService;
        }

        [BindProperty]
        public MeumLibrary.Model.Lager Lager { get; set; }


        public void OnGet(int id)
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            Lager = _lagerService.GetByID(id);
        }

        public IActionResult OnPost(int id)
        {
            MeumLibrary.Model.Lager deletedLager = _lagerService.Delete(id);
            return Redirect("/Lager/Lager");
        }

    }
}
