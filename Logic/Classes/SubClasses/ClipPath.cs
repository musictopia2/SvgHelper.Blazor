namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class ClipPath : BaseElement, IParentGraphic
{
    public BasicList<IStart> Children { get; set; } = new();
}