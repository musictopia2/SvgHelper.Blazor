namespace SvgHelper.Blazor.Logic.Classes;
public class CustomEventClass
{
    public Func<object, object, Task>? ActionClicked { get; set; }
    public object? CommandParameters { get; set; }
    public object? ExtraDetails { get; set; }
    public bool StopPropagation; //i like this way better.
}