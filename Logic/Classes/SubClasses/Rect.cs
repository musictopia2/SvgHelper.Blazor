namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Rect : BaseElement, IImageSize
{
    public bool CaptureRef { get; set; } = false;
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public string RX { get; set; } = "0";
    public string RY { get; set; } = "0";
    public string Width { get; set; } = "";
    public string Height { get; set; } = "";
    public string Fill { get; set; } = "none";
    public string Fill_Opacity { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass(); //i like this way better.
    public string Transform { get; set; } = ""; //i think.
    public string Marker_Start { get; set; } = "";
    public string Marker_Mid { get; set; } = "";
    public string Marker_End { get; set; } = "";
    public string Mask { get; set; } = "";
}