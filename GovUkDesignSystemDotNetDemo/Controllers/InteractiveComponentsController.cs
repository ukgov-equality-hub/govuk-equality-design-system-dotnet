using GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;
using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

[Route("interactive-components")]
public class InteractiveComponentsController : Controller
{
    [HttpGet("text-input-for")]
    public IActionResult TextInputFor() => View();

    [HttpGet("text-input-for/examples/default")]
    public IActionResult TextInputForExampleDefault()
    {
        return View("TextInputForExampleDefault", new TextInputForExampleDefaultViewModel());
    }

    [HttpPost("text-input-for/examples/default")]
    public IActionResult TextInputForExampleDefault(TextInputForExampleDefaultViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("TextInputForExampleDefault", viewModel);
        }

        return View("InteractiveExampleValidationSuccessful");
    }
}
