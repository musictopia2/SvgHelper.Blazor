namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class RadialGradient : IParentGraphic
{
    public string ID { get; set; } = "";
    public string CX { get; set; } = "0";
    public string CY { get; set; } = "0";
    public string R { get; set; } = "";
    public string FX { get; set; } = "0";
    public string FY { get; set; } = "0";
    public string FR { get; set; } = "0";
    public BasicList<object> Children { get; set; } = new();
}