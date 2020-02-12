using IdentityPOC.Common.Models;
using IdentityPOC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPOC.Web.Controllers
{
    public class ExternalController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}