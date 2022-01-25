namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class G : IParentGraphic
{
    public string ID { get; set; } = "";
    public string Transform { get; set; } = "";
    public string Font_Family { get; set; } = "";
    public string Text_Anchor { get; set; } = "";
    public string Fill { get; set; } = "";
    public string Mask { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
    public BasicList<object> Children { get; set; } = new();
    public string ClipPath { get; set; } = "";
}