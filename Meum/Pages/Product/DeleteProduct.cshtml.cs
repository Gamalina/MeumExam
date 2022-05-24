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

namespace Meum.Pages.Product
{
    public class DeleteProductModel : PageModel
    {

        private IProduktDB _produtService;

        public DeleteProductModel(IProduktDB produktService)
        {
            _produtService = produktService;
        }

        [BindProperty]
        public Produkt Produkt { get; set; }


        public void OnGet(int id)
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            Produkt = _produtService.GetByID(id);
        }

        public IActionResult OnPost(int id)
        {
            Produkt deletedProdukt = _produtService.Delete(id);
            return Redirect("/Product/Products");
        }
    }
}
