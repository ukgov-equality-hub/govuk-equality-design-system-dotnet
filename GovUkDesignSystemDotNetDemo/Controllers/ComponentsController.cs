using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

[Route("components")]
public class ComponentsController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View();

    [HttpGet("back-link")]
    public IActionResult BackLink() => View();

    [HttpGet("breadcrumbs")]
    public IActionResult Breadcrumbs() => View();

    [HttpGet("button")]
    public IActionResult Button() => View();

    [HttpGet("header")]
    public IActionResult Header() => View();

    [HttpGet("examples/{exampleName}")]
    public IActionResult ExamplePage(string exampleName)
    {
        return View(exampleName);
    }
}
