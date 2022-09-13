namespace SvgHelper.Blazor.Logic.Classes.Interfaces;
public interface IStart
{
    //here, has to decide what the source generate will eventually implement.
    bool HasSpecificProperty(string name);
    bool GetCapturedRef { get; }
    string GetSpecificProperty(string name);
    string TypeUsed { get; }
    int RenderUpTo { get; set; }
    BasicList<CustomProperty> Properties();
    BasicList<IStart> GetChildren { get; } //if there is none, just return 0.
}