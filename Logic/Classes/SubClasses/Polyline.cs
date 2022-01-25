namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Polyline : BaseElement
{
    public bool CaptureRef { get; set; } = false;
    public string Points { get; set; } = "";
    public string Transform { get; set; } = "";
    public string Opacity { get; set; } = "0";
    public string Fill { get; set; } = "none";
    public string Fill_Opacity { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
    public string Mask { get; set; } = "";
    public string Marker_Start { get; set; } = "";
    public string Marker_Mid { get; set; } = "";
    public string Marker_End { get; set; } = "";
}