namespace GovUkDesignSystemDotNet;

public class CheckboxesViewModel
{
    public List<string> DescribedBy { get; set; } = [];
    public FieldsetViewModel Fieldset { get; set; }
    public HintViewModel Hint { get; set; }
    public ErrorMessageViewModel ErrorMessage { get; set; }
    public FormGroupViewModel FormGroup { get; set; }
    public string IdPrefix { get; set; }
    public string Name { get; set; }
    public List<CheckboxItemViewModel> CheckboxItems { get; set; } = [];
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
