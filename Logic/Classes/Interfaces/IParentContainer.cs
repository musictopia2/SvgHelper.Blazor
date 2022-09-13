namespace SvgHelper.Blazor.Logic.Classes.Interfaces;
public interface IParentContainer : IParentGraphic //only g and svg is supported for this.
{
    int ManuelUpTo { get; internal set; }
}