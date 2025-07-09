using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }
}
