namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Mask : IParentGraphic
{
    public string ID { get; set; } = "";
    public BasicList<object> Children { get; set; } = new();
}