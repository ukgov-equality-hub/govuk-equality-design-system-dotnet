using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

[Route("components")]
public class ComponentsController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("examples/{exampleName}")]
    public IActionResult ExamplePage(string exampleName)
    {
        return View(exampleName);
    }
}
