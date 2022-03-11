namespace SvgHelper.Blazor.Logic;
public class SvgRenderClass
{
    public Dictionary<string, ElementReference> ElementReferences = new();
    public bool Allow0 { get; set; } = false; //if 0s are allowed, then display when needed.
    public void ResetDictionary()
    {
        ElementReferences = new Dictionary<string, ElementReference>();
    }
    private static void ActionClicked(CustomEventClass customEvent)
    {
        customEvent.ActionClicked!.Invoke(customEvent.CommandParameters!, customEvent.ExtraDetails!);
    }
    public void RenderSvgTree<T>(BasicList<T> objects, int k, RenderTreeBuilder builder)
        where T: IStart
    {
        objects.ForEach(obj =>
        {
            RenderSvgTree(obj, k, builder);
        });
    }
    private static (bool captureRef, string value_id, string classID) CaptureInfo<T>(T item)
        where T : IStart
    {
        bool capturedRef = false;
        string value_id = string.Empty;
        string classID = string.Empty;
        if (item is null || item.HasSpecificProperty("CaptureRef") == false)
        {
            return (capturedRef, value_id, classID);
        }
        if (item.GetCapturedRef == false)
        {
            return (capturedRef, value_id, classID);
        }
        if (item.HasSpecificProperty("ID"))
        {
            value_id = item.GetSpecificProperty("ID");
            capturedRef = string.IsNullOrWhiteSpace(value_id) == false;
        }
        if (item.HasSpecificProperty("CssClass"))
        {
            classID = item.GetSpecificProperty("CssClass");
        }
        return (capturedRef, value_id, classID);
    }
    public void RenderSvgTree<T>(T item, int k, RenderTreeBuilder builder)
        where T : IStart
    {
        builder.OpenRegion(k++);
        (bool captureRef, string value_id, string classID) = CaptureInfo(item);
        object? _value;
        string _attrName = string.Empty;
        bool isAllowed;
        string tempName = FirstAndLastCharacterToLower(item!.GetType().Name);
        builder.OpenElement(k++, tempName);
        BasicList<CustomProperty> properties = item.Properties();
        //the content being added has to be in the source generator as well.
        foreach (var p in properties)
        {
            isAllowed = true;
            _value = p.Value!;
            if (p.IsDouble)
            {
                if (double.IsNaN((double)_value))
                {
                    isAllowed = false;
                }
                else
                {
                    _value = Math.Round((double)_value, 2);
                }
                //future:
                //since only text obviously allows 0, then instead of setting the property, it will check to see if its text
                //if text, then allow
                //if not text, but shows 0, then not allowed.
            }
            if (isAllowed)
            {
                isAllowed = _value != null && !string.IsNullOrEmpty(_value.ToString());
                if (isAllowed && _value!.ToString() == "0" && Allow0 == false)
                {
                    isAllowed = false;
                }
                if (_value!.ToString() == "0" && Allow0 && item is Text == false)
                {
                    isAllowed = false;
                }
            }
            if (isAllowed)
            {
                _attrName = p.AttributeName;
                if (_value is CustomEventClass custom)
                {
                    if (custom.ActionClicked != null)
                    {
                        builder.AddAttribute(1, "onclick", EventCallback.Factory.Create(this, e => ActionClicked(custom)));
                    }
                    if (custom.StopPropagation)
                    {
                        builder.AddEventStopPropagationAttribute(2, "onclick", true);
                    }
                }
                else
                {
                    if (_attrName.Equals("Content"))
                    {
                        builder.AddContent(3, _value!.ToString());
                    }
                    else if (_attrName.Equals("CssClass"))
                    {
                        builder.AddAttribute(4, "class", _value!.ToString());
                    }
                    else
                    {
                        if (_attrName.Contains('_'))
                        {
                            _attrName = _attrName.Replace("_", "-");
                        }
                        _attrName = FirstAndLastCharacterToLower(_attrName);
                        builder.AddAttribute(4, _attrName, _value!.ToString());
                    }
                }
            }
        }
        BasicList<IStart> children = item.GetChildren;
        foreach (var c in children)
        {
            RenderSvgTree(c, k++, builder);
        }
        if (captureRef)
        {
            builder.AddElementReferenceCapture(5, (elementReference) =>
            {
                ElementReferences.Add(value_id!, elementReference);
            });
        }
        builder.CloseElement();
        builder.CloseRegion();
    }
    internal static string FirstAndLastCharacterToLower(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }
        if (str.Length <= 3)
        {
            return str.ToLower();
        }
        int lastIndex = str.Length - 1;
        if (str == "RefX")
        {
            return "refX";
        }
        if (str == "Font-Weight")
        {
            return "font-weight";
        }
        if (str == "RefY")
        {
            return "refY";
        }
        if (str == "Font-Size")
        {
            return "font-size";
        }
        if (str == "Text-Anchor")
        {
            return "text-anchor";
        }
        if (str == "Dominant-Baseline")
        {
            return "dominant-baseline";
        }
        if (str == "Stop-Color")
        {
            return "stop-color";
        }
        if (str == "Stop-Opacity")
        {
            return "stop-opacity";
        }
        if (str == "Fill-Opacity")
        {
            return "fill-opacity";
        }
        if (str == "Href")
        {
            return "href";
        }
        if (str == "ClipPath")
        {
            return "clippath";
        }
        if (char.IsLower(str, 0) == false && char.IsLower(str, lastIndex) == false)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1, str.Length - 2) + char.ToLowerInvariant(str[lastIndex]);
        }
        if (char.IsLower(str, 0) == true && char.IsLower(str, lastIndex) == true)
        {
            return str;
        }
        if (char.IsLower(str, 0) == false)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
        return str.Substring(0, lastIndex - 2) + char.ToLowerInvariant(str[lastIndex]);
    }
}