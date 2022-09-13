namespace SvgHelper.Blazor.Logic.Classes.Interfaces;
public interface ISvg : IParentContainer, IStart
{
    bool CaptureRef { get; set; }
    CustomEventClass EventData { get; set; }
    string Height { get; set; }
    string Mask { get; set; }
    string PreserveAspectRatio { get; set; }
    string Transform { get; set; }
    string ViewBox { get; set; }
    string Width { get; set; }
    string X { get; set; }
    string Y { get; set; }
    string Xmlns { get; set; }
    string ClassName { get; set; }
    string ID { get; set; }
    string Style { get; set; }
}