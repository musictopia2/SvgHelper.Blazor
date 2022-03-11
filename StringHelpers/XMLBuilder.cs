namespace SvgHelper.Blazor.StringHelpers;
public class XMLBuilder
{
    readonly BasicList<string> _tags = new();
    int _indentLevel;
    StringBuilder _builder = new();
    EnumStatus _status = EnumStatus.Normal;
    bool _needsClose = true;
    public void Clear()
    {
        _builder.Clear();
        _tags.Clear();
        _indentLevel = 0;
    }
    public void OpenElement(string value)
    {
        if (_needsClose && _tags.Count > 0)
        {
            _builder.AppendLine(">");
        }
        if (_tags.Count > 0)
        {
            _builder.Append(GetTabs());
        }
        _builder.Append($"<{value} ");
        _indentLevel++;
        _tags.Add(value);
    }
    private string GetTabs()
    {
        string value = "";
        for (int i = 0; i < _indentLevel; i++)
        {
            value += VBTab;
        }
        return value;
    }
    private void WriteLine(string value)
    {
        _builder.AppendLine($"{GetTabs()}{value} ");
    }
    public void CloseElement()
    {
        if (_status == EnumStatus.SameLine)
        {
            _builder.Append($"</{_tags.Last()}>");
            _needsClose = false;
            _status = EnumStatus.Normal;
            _tags.RemoveLastItem();
            _indentLevel--;
        }
        else if (_status == EnumStatus.SelfClose)
        {
            _needsClose = true;
            _builder.Append($"/"); //let it do it automatically.
            _tags.RemoveLastItem(); //still do this.
            _indentLevel--;
            _status = EnumStatus.Normal;
        }
        else
        {
            _needsClose = true;
            _indentLevel--;
            _builder.AppendLine();
            WriteLine($"</{_tags.Last()}>");
            _tags.RemoveLastItem();
        }
    }
    public void AddAttribute(string name, string value)
    {
        _status = EnumStatus.SelfClose;
        _builder.Append($"{name}={QQ}{value}{QQ} ");
    }
    public void AddContent(string content)
    {
        _status = EnumStatus.SameLine;
        _builder.Append($">{content}");
    }
    public string GetContent()
    {
        string content = _builder.ToString();
        BasicList<string> lines = content.Split(VBCrLf).ToBasicList();
        BasicList<string> needed = new();
        foreach (var line in lines)
        {
            if (line != ">" && line != "")
            {
                needed.Add(line); //since i could not make it figure out when it needed the > (closing tag), then i had to remove any blank lines of ones with extra tags.
            }
        }
        content = string.Join(VBCrLf, needed);
        return content;
    }
}