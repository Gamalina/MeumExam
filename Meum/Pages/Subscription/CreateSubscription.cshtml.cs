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

namespace Meum.Pages.Subscription
{
    public class CreateSubscriptionModel : PageModel
    {
        private IAbonnomentDB _abonnomentService;
        [BindProperty]
        public Abonnoment Abonnoment { get; set; }

        public CreateSubscriptionModel(IAbonnomentDB abonnomentService)
        {
            _abonnomentService = abonnomentService;
        }

        public void OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            Abonnoment = new Abonnoment();
        }

        public IActionResult OnPost()
        {
            _abonnomentService.Create(Abonnoment);
            return Redirect("/Subscription/Subscriptions");
        }
    }
}
