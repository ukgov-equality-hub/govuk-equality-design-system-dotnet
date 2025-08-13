namespace GovUkDesignSystemDotNet;

public class FileUploadViewModel
{
    public string Name { get; set; }
    public string Id { get; set; }
    public bool Disabled { get; set; }
    public bool Multiple { get; set; }
    public List<string> DescribedBy { get; set; } = [];
    public LabelViewModel Label { get; set; }
    public HintViewModel Hint { get; set; }
    public ErrorMessageViewModel ErrorMessage { get; set; }
    public FormGroupViewModel FormGroup { get; set; }
    public bool Javascript { get; set; }
    public string ChooseFilesButtonText { get; set; }
    public string DropInstructionText { get; set; }
    public PluralisationOptions MultipleFilesChosenText { get; set; }
    public string NoFileChosenText { get; set; }
    public string EnteredDropZoneText { get; set; }
    public string LeftDropZoneText { get; set; }
    public List<string> Classes { get; set; } = [];
    public Dictionary<string, string> Attributes { get; set; }
}
