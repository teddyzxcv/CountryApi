using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CountryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}