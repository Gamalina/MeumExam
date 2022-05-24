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
    public class DeleteSubscriptionModel : PageModel
    {
        private IAbonnomentDB _abonnomentService;

        public DeleteSubscriptionModel(IAbonnomentDB abonnomentService)
        {
            _abonnomentService = abonnomentService;
        }

        [BindProperty]
        public Abonnoment Abonnoment { get; set; }

        public void OnGet(int id)
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            Abonnoment = _abonnomentService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            Abonnoment deletedAbonnoment = _abonnomentService.Delete(id);
            return Redirect("/Subscription/Subscriptions");
        }
    }
}
