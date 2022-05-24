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
    public class EditSubscriptionModel : PageModel
    {
        private IAbonnomentDB _abonnomentService;

        public EditSubscriptionModel(IAbonnomentDB abonnomentService)
        {
            _abonnomentService = abonnomentService;
        }

        [BindProperty]
        public Abonnoment Abonnoment { get; set; }

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
                Abonnoment = _abonnomentService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"Et abonnoment med det id findes ikke.";
            }
        }

        public IActionResult OnPost(int id)
        {
            Abonnoment.Id = id;
            _abonnomentService.Modify(Abonnoment);

            return RedirectToPage("/Subscription/Subscriptions");
        }
    }
}
