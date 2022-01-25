namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Use : BaseElement
{
    public bool CaptureRef { get; set; } = false;
    public string Width { get; set; } = "";
    public string Height { get; set; } = "";
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public string Href { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
    public string Transform { get; set; } = "";
    public string ViewBox { get; set; } = "";
    public string Fill { get; set; } = "none";
    public string Fill_Opacity { get; set; } = "";
    public string PreserveAspectRatio { get; set; } = "";
}