namespace SvgHelper.Blazor.StringHelpers;
public class SvgBuilderClass
{
    public bool Allow0 { get; set; } = false;
    public void RenderSvgXml<T>(BasicList<T> objects, XMLBuilder builder)
        where T : IStart
    {
        objects.ForEach(obj =>
        {
            RenderSvgXml(obj, builder);
        });
    }
    public void RenderSvgXml<T>(T item, XMLBuilder builder)
        where T : IStart
    {
        object? _value;
        string _attrName;
        bool isAllowed;
        string tempName = FirstAndLastCharacterToLower(item!.GetType().Name);
        builder.OpenElement(tempName);
        //var items = item.GetChildren;
        BasicList<CustomProperty> properties = item.Properties();
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

                if (_value is not CustomEventClass)
                {
                    if (_attrName.Equals("Content"))
                    {
                        builder.AddContent(_value!.ToString()!);
                    }
                    else if (_attrName.Equals("CssClass"))
                    {
                        builder.AddAttribute("class", _value!.ToString()!);
                    }
                    else
                    {
                        if (_attrName.Contains('_'))
                        {
                            _attrName = _attrName.Replace("_", "-");
                        }
                        _attrName = FirstAndLastCharacterToLower(_attrName);
                        builder.AddAttribute(_attrName, _value!.ToString()!);
                    }
                }
            }
        }
        BasicList<IStart> children = item.GetChildren;
        foreach (var c in children)
        {
            RenderSvgXml(c, builder);
        }
        builder.CloseElement();
    }


    //this is copied from the svgrenderclass.  eventually put back in when i figure out how it makes sense.
    private static string FirstAndLastCharacterToLower(string str)
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
