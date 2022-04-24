using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic;
public static class TextFontHelpers
{
    //this means for global, i can specify that if on android, then can change it.  this is not the place to specify it
    public static string BorderedTextFontFamily { get; set; } = "tahoma";
}
