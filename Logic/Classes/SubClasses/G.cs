namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class G : IParentContainer
{
    public string ID { get; set; } = "";
    public string Transform { get; set; } = "";
    public string Font_Family { get; set; } = "";
    public string Text_Anchor { get; set; } = "";
    public string Fill { get; set; } = "";
    public string Mask { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
    public BasicList<IStart> Children { get; set; } = new();
    int IParentContainer.ManuelUpTo { get; set; } = 1000;
    public string ClipPath { get; set; } = "";
    public int RenderUpTo { get; set; }
}