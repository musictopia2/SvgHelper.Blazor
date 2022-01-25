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
    public void RenderSvgTree(BasicList<object> objects, int k, RenderTreeBuilder builder)
    {
        objects.ForEach(obj =>
        {
            RenderSvgTree(obj, k, builder);
        });
    }
    public void RenderSvgTree<T>(T item, int k, RenderTreeBuilder builder)
    {
        builder.OpenRegion(k++);
        bool captureRef = false;
        string value_id = string.Empty;
        string classID = string.Empty;
        if (item!.GetType().GetProperties().Any(x => x.Name == "CaptureRef"))
        {
            PropertyInfo pi_captureref = item.GetType().GetProperty("CaptureRef")!;
            if ((bool)pi_captureref.GetValue(item, null)!)
            {
                if (item.GetType().GetProperties().Any(x => x.Name == "ID"))
                {
                    PropertyInfo pi_id = item.GetType().GetProperty("ID")!;
                    value_id = pi_id.GetValue(item, null)!.ToString()!;
                    captureRef = value_id != null && !string.IsNullOrEmpty(value_id.ToString());
                }
                if (item.GetType().GetProperties().Any(x => x.Name == "CssClass"))
                {
                    PropertyInfo pi_id = item.GetType().GetProperty("CssClass")!;
                    classID = pi_id.GetValue(item, null)!.ToString()!;
                }
            }
        }
        object _value;
        string _attrName = string.Empty;
        bool isAllowed = true;
        string tempName = FirstAndLastCharacterToLower(item.GetType().Name);
        builder.OpenElement(k++, tempName);
        BasicList<PropertyInfo> properties = item.GetType().GetProperties().Where(x => !x.PropertyType.Name.Contains("CustomBasicList") && x.Name != "Content" && !x.PropertyType.Name.Contains("CaptureRef")).ToBasicList();
        PropertyInfo property = item.GetType().GetProperties().Where(x => x.Name == "Content").SingleOrDefault()!;
        if (property != null)
        {
            properties.Add(property);
        }
        foreach (PropertyInfo pi in properties)
        {
            if (pi.Name != "CaptureRef")
            {
                isAllowed = true;
                _value = pi.GetValue(item, null)!;
                if (pi.PropertyType == typeof(double))
                {
                    if (double.IsNaN((double)_value))
                    {
                        isAllowed = false;
                    }
                    else
                    {
                        _value = Math.Round((double)_value, 2);
                    }
                }
                //future:
                //since only text obviously allows 0, then instead of setting the property, it will check to see if its text
                //if text, then allow
                //if not text, but shows 0, then not allowed.
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
                    _attrName = pi.Name;
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
        }
        PropertyInfo pi_Children = item.GetType().GetProperty("Children")!;
        if (pi_Children != null)
        {
            BasicList<object>? children = pi_Children.GetValue(item) as BasicList<object>;
            foreach (object others in children!)
            {
                RenderSvgTree(others, k++, builder); ;
            }
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