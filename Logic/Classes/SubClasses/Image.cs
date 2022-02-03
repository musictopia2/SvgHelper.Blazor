namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class Image : BaseElement
{
    public bool CaptureRef { get; set; } = false;
    public string Href { get; set; } = "";
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public string Width { get; set; } = "0";
    public string Height { get; set; } = "0";
    public string Transform { get; set; } = "";
    public string Opacity { get; set; } = "0";
    public string Mask { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
}