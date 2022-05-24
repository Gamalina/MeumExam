using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meum.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MeumLibrary.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Meum.Pages.Login
{
    public class LoginModel : PageModel
    {

        private IBrugerServiceDB _brugerService;

        public static Bruger LoggedInUser { get; set; } = null;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public LoginModel(IBrugerServiceDB brugerService)
        {
            _brugerService = brugerService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            List<Bruger> users = _brugerService.GetAll();

            foreach (Bruger u in users)
            {
                if (UserName == u.BrugerNavn && Password == u.Adgangskode)
                {
                    LoggedInUser = u;

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, UserName),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");

                }
            }

            Message = "Brugernavn eller adgangskode er forkert. Prøv igen.";
            return Page();
        }
    }
}
