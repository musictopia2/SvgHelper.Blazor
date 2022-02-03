namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class LinearGradient : IParentGraphic
{
    public string ID { get; set; } = "";
    public string X1 { get; set; } = "0";
    public string Y1 { get; set; } = "0";
    public string X2 { get; set; } = "0";
    public string Y2 { get; set; } = "0";
    public string GradientUnits { get; set; } = "";
    public BasicList<IStart> Children { get; set; } = new();
}