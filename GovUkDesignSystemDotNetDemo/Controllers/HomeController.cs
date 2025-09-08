using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("/health-check")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}
