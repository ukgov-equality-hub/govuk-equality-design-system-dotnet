using GovUkDesignSystemDotNetDemo.Models.InteractiveComponentsExamples;
using Microsoft.AspNetCore.Mvc;

namespace GovUkDesignSystemDotNetDemo.Controllers;

[Route("interactive-components")]
public class InteractiveComponentsController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View();

    
    [HttpGet("character-count-for")]
    public IActionResult CharacterCountFor() => View();

    [Route("CharacterCountForExampleDefault")]
    public IActionResult CharacterCountForExampleDefault(CharacterCountForExampleDefaultViewModel vm) => ExampleDefault(vm);

    [HttpGet("error-summary-if-needed")]
    public IActionResult ErrorSummaryIfNeeded() => View();

    [Route("ErrorSummaryIfNeededExampleDefault")]
    public IActionResult ErrorSummaryIfNeededExampleDefault(ErrorSummaryIfNeededExampleDefaultViewModel vm) => ExampleDefault(vm);

    [HttpGet("file-upload-for")]
    public IActionResult FileUploadFor() => View();

    [Route("FileUploadForExampleDefault")]
    public IActionResult FileUploadForExampleDefault(FileUploadForExampleDefaultViewModel vm) => ExampleDefault(vm,
        () =>
        {
            if (vm.YourCsvFile == null)
            {
                ModelState.AddModelError(nameof(vm.YourCsvFile), "Upload a CSV file");
            }
        });

    [HttpGet("textarea-for")]
    public IActionResult TextareaFor() => View();

    [Route("TextareaForExampleDefault")]
    public IActionResult TextareaForExampleDefault(TextareaForExampleDefaultViewModel vm) => ExampleDefault(vm);

    [HttpGet("text-input-for")]
    public IActionResult TextInputFor() => View();

    [Route("TextInputForExampleDefault")]
    public IActionResult TextInputForExampleDefault(TextInputForExampleDefaultViewModel vm) => ExampleDefault(vm);

    [HttpGet("radios-for")]
    public IActionResult RadiosFor() => View();

    [Route("RadiosForExampleDefault")]
    public IActionResult RadiosForExampleDefault(RadiosForExampleDefaultViewModel vm) => ExampleDefault(vm);

    
    private IActionResult ExampleDefault<TViewModel>(TViewModel viewModel, Action extraValidation = null)
    where TViewModel : new()
    {
        string actionName = ControllerContext.RouteData.Values["action"].ToString();
        
        switch (Request.Method)
        {
            case "GET":
                ModelState.Clear();
                return View(actionName, new TViewModel());

            case "POST":
                if (extraValidation != null)
                {
                    extraValidation();
                }
                
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
