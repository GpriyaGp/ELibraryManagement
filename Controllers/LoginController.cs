using ELibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Success(LoginView loginView)
        {
            if (loginView.Name != null && loginView.Password != null)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Login");
        }
    }
}
