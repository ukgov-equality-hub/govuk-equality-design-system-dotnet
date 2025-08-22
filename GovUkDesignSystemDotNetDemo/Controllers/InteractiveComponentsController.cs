using GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;
using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

[Route("interactive-components")]
public class InteractiveComponentsController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View();

    
    [HttpGet("textarea-for")]
    public IActionResult TextareaFor() => View();

    [Route("TextareaForExampleDefault")]
    public IActionResult TextareaForExampleDefault(TextareaForExampleDefaultViewModel vm) => ExampleDefault(vm);

    [HttpGet("text-input-for")]
    public IActionResult TextInputFor() => View();

    [Route("TextInputForExampleDefault")]
    public IActionResult TextInputForExampleDefault(TextInputForExampleDefaultViewModel vm) => ExampleDefault(vm);

    
    private IActionResult ExampleDefault<TViewModel>(TViewModel viewModel)
    where TViewModel : new()
    {
        string actionName = ControllerContext.RouteData.Values["action"].ToString();
        
        switch (Request.Method)
        {
            case "GET":
                ModelState.Clear();
                return View(actionName, new TViewModel());

            case "POST":
                if (!ModelState.IsValid)
                {
                    return View(actionName, viewModel);
                }

                return View("InteractiveExampleValidationSuccessful");
            
            default:
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }
    }
}
