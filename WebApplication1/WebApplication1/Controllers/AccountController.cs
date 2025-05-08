using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.ViewModels.Account;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext _context;

        public AccountController(AppDbContext context) { _context = context; }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid )
            {
                return View();

            }
            return Json(registerVm);
        }

        
    }
}
