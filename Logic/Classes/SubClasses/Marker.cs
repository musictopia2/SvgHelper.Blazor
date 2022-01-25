namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Marker : BaseElement, IParentGraphic
{
    public string ViewBox { get; set; } = "";
    public double RefX { get; set; } = double.NaN;
    public double RefY { get; set; } = double.NaN;
    public double MarkerWidth { get; set; } = double.NaN;
    public double MarkerHeight { get; set; } = double.NaN;
    public string Orient { get; set; } = "";
    public string PreserveAspectRatio { get; set; } = "";
    public string Mask { get; set; } = "";
    public BasicList<object> Children { get; set; } = new();
}