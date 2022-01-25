namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Line : BaseElement
{
    public bool CaptureRef { get; set; } = false;
    public string X1 { get; set; } = "0";
    public string Y1 { get; set; } = "0";
    public string X2 { get; set; } = "0";
    public string Y2 { get; set; } = "0";
    public string Transform { get; set; } = "";
    public string Opacity { get; set; } = "0";
    public string Marker_Start { get; set; } = "";
    public string Marker_Mid { get; set; } = "";
    public string Marker_End { get; set; } = "";
    public string Mask { get; set; } = "";
}