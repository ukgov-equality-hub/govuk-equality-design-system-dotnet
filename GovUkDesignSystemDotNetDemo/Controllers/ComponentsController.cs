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
    
    [HttpGet("back-link")]
    public IActionResult BackLink()
    {
        return View();
    }
    
    [HttpGet("button")]
    public IActionResult Button()
    {
        return View();
    }
    
    [HttpGet("breadcrumbs")]
    public IActionResult Breadcrumbs()
    {
        return View();
    }
    
    [HttpGet("header")]
    public IActionResult Header()
    {
        return View();
    }
    
    [HttpGet("examples/{exampleName}")]
    public IActionResult ExamplePage(string exampleName)
    {
        return View(exampleName);
    }
}
