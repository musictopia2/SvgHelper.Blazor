namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Image : BaseElement
{
    public string Href { get; set; } = "";
    public bool CaptureRef { get; set; } = false;
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public string Width { get; set; } = "0";
    public string Height { get; set; } = "0";
    public string Transform { get; set; } = "";
    public string Opacity { get; set; } = "0";
    public string Mask { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
}