namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public partial class SVG : BaseElement, IImageSize, IParentGraphic, ISvg
{
    public bool CaptureRef { get; set; } = false;
    public string Width { get; set; } = "";
    public string Height { get; set; } = "";
    public CustomEventClass EventData { get; set; } = new CustomEventClass();
    public string Transform { get; set; } = "";
    public string Xmlns { get; set; } = "http://www.w3.org/2000/svg";
    public string ViewBox { get; set; } = "";
    public string PreserveAspectRatio { get; set; } = "";
    public string Mask { get; set; } = "";
    public string X { get; set; } = "0";
    public string Y { get; set; } = "0";
    public BasicList<IStart> Children { get; set; } = new();
}