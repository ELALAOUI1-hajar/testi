using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using testi.Models;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {

        return RedirectToAction("Index", "Admin");
    }

 }
