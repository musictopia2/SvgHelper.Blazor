namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class Mask : IParentGraphic
{
    public string ID { get; set; } = "";
    public BasicList<IStart> Children { get; set; } = new();
}