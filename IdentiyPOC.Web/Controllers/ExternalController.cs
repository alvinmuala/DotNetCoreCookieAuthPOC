using IdentityPOC.Common.Models;
using IdentityPOC.Data;
using IdentityPOC.Security;
using IdentityPOC.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPOC.Web.Controllers
{
    [AllowAnonymous]
    public class ExternalController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ExternalController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var loginResult = IdentityPOCAuthentication.Login(_dbContext, HttpContext, userLogin);

            switch (loginResult)
            {
                case LoginResult.MemberNotFound:
                    ViewBag.Error = "Invalid Username or Password";
                    return View(userLogin);

                case LoginResult.Success:
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Unable to login using the info provided.Please try again later";
            return View(userLogin);
        }

        public IActionResult SignOut()
        {
            IdentityPOCAuthentication.SignOut(HttpContext);
            return RedirectToAction("Login");
        }
    }
}