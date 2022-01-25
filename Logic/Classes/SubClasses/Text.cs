namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class Text : BaseElement
{
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public string Width { get; set; } = "0";
    public string Height { get; set; } = "0";
    public string Transform { get; set; } = "";
    public string Fill { get; set; } = "black"; 
    public double Font_Size { get; set; } = double.NaN;
    public double Opacity { get; set; } = double.NaN;
    public string Font_Weight { get; set; } = "";
    public string Text_Anchor { get; set; } = "";
    public string Dominant_Baseline { get; set; } = "";
    public string Transform_Origin { get; set; } = "";
    public BasicList<object> Children { get; set; } = new();
    public string Content { get; set; } = "";
}