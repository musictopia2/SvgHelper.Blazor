namespace SvgHelper.Blazor.Logic;
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
        string tempName = SvgRenderClass.FirstAndLastCharacterToLower(item!.GetType().Name);
        builder.OpenElement(tempName);
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
                        _attrName = SvgRenderClass.FirstAndLastCharacterToLower(_attrName);
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
}
