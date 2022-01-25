namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Pattern : IParentGraphic
{
    public string ID { get; set; } = "";
    public string ViewBox { get; set; } = "";
    public string Mask { get; set; } = "";
    public string Width { get; set; } = "";
    public string Height { get; set; } = "";
    public string PreserveAspectRatio { get; set; } = "";
    public string Href { get; set; } = "";
    public BasicList<object> Children { get; set; } = new();
}