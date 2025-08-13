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

    [HttpGet("character-count")]
    public IActionResult CharacterCount() => View();

    [HttpGet("checkbox-item")]
    public IActionResult CheckboxItem() => View();

    [HttpGet("checkboxes")]
    public IActionResult Checkboxes() => View();

    [HttpGet("error-message")]
    public IActionResult ErrorMessage() => View();

    [HttpGet("error-summary")]
    public IActionResult ErrorSummary() => View();

    [HttpGet("fieldset")]
    public IActionResult Fieldset() => View();

    [HttpGet("footer")]
    public IActionResult Footer() => View();

    [HttpGet("header")]
    public IActionResult Header() => View();

    [HttpGet("hint")]
    public IActionResult Hint() => View();

    [HttpGet("label")]
    public IActionResult Label() => View();

    [HttpGet("phase-banner")]
    public IActionResult PhaseBanner() => View();

    [HttpGet("radio-item")]
    public IActionResult RadioItem() => View();

    [HttpGet("radios")]
    public IActionResult Radios() => View();

    [HttpGet("service-navigation")]
    public IActionResult ServiceNavigation() => View();

    [HttpGet("tag")]
    public IActionResult Tag() => View();

    [HttpGet("textarea")]
    public IActionResult Textarea() => View();

    [HttpGet("text-input")]
    public IActionResult TextInput() => View();

    [HttpGet("examples/{exampleName}")]
    public IActionResult ExamplePage(string exampleName)
    {
        return View(exampleName);
    }
}
