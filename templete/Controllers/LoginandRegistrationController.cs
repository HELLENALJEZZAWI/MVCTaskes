using Microsoft.AspNetCore.Mvc;

namespace templete.Controllers
{
    public class LoginandRegistrationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
