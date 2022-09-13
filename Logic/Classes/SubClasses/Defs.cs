namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class Defs : IParentGraphic
{
    public BasicList<IStart> Children { get; set; } = new();
    public int RenderUpTo { get; set; }
}