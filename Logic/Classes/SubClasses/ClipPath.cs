﻿namespace SvgHelper.Blazor.Logic.Classes.SubClasses;
public class ClipPath : BaseElement, IParentGraphic
{
    public BasicList<object> Children { get; set; } = new();
}