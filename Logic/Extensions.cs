namespace SvgHelper.Blazor.Logic;
public static class Extensions
{
    public static void AutoIncrementElement(this IStart start, IParentContainer parent)
    {
        start.RenderUpTo = parent.ManuelUpTo;
        parent.ManuelUpTo++;
    }
    public static void PopulateFullExternalImage(this Image image, string name)
    {
        string text = ff2.GetFile(name);
        image.Href = text;
    }
    public static void PopulateStrokesToStyles(this BaseElement element, string color = "black", float strokeWidth = 1, string fontFamily = "default", double opacity = 1)
    {
        if (fontFamily == "default")
        {
            fontFamily = TextFontHelpers.BorderedTextFontFamily; //do here.  for now, only for doing strokes to styles.
        }
        element.Style = $"stroke: {color}; stroke-width: {strokeWidth}px; stroke-miterlimit:4; font-family:{fontFamily}; opacity: {opacity}";
    }
    public static void PopulateTextFont(this Text text, string fontFamily = "Lato")
    {
        text.Style = $"font-family:{fontFamily};";
    }
    public static void PopulateImageSize(this IImageSize image, Size size)
    {
        image.Width = size.Width.ToString();
        image.Height = size.Height.ToString();
    }
    public static void PopulateImageSize(this IImageSize image, double width, double height)
    {
        image.Width = width.ToString();
        image.Height = height.ToString();
    }
    public static void PopulateImagePositionings(this Image image, RectangleF rect)
    {
        image.Width = rect.Width.ToString();
        image.Height = rect.Height.ToString();
        image.X = rect.X.ToString();
        image.Y = rect.Y.ToString();
    }
    public static void PopulateImagePositionings(this Image image, Rect rect)
    {
        image.Width = rect.Width;
        image.Height = rect.Height;
        image.X = rect.X;
        image.Y = rect.Y;
    }
    public static void PopulateImagePositionings(this Image image, float x, float y, float width, float height)
    {
        image.Width = width.ToString();
        image.Height = height.ToString();
        image.X = x.ToString();
        image.Y = y.ToString();
    }
    public static void CenterText(this Text text, IParentGraphic parent, RectangleF rect)
    {
        text.CenterText(parent, rect.X, rect.Y, rect.Width, rect.Height);
    }
    public static void CenterText(this Text text, IParentGraphic parent, Rect rect)
    {
        ISvg svg = new SVG();
        parent.Children.Add(svg);
        svg.X = rect.X;
        svg.Y = rect.Y;
        svg.Width = rect.Width;
        svg.Height = rect.Height;
        svg.Children.Add(text);
        text.CenterText();
    }
    public static void CenterText(this Text text, IParentGraphic parent, float x, float y, float width, float height)
    {
        ISvg svg = new SVG();
        parent.Children.Add(svg);
        svg.X = x.ToString();
        svg.Y = y.ToString();
        svg.Width = width.ToString();
        svg.Height = height.ToString();
        svg.Children.Add(text);
        text.CenterText();
    }
    public static void CenterText(this Text text)
    {
        text.Width = "100%";
        text.Height = "100%";
        text.X = "50%";
        text.Y = "55%";
        text.Dominant_Baseline = "middle";
        text.Text_Anchor = "middle";
    }
    public static string ColorUsed(this string color)
    {
        if (color == cc1.Transparent)
        {
            return "none"; //this is how svg shows as transparent
        }
        if (color.Length == 0)
        {
            throw new CustomBasicException("Had no color");
        }
        if (color.Length != 9)
        {
            throw new CustomBasicException("Color In Wrong Format");
        }
        if (color.StartsWith("#FF") == false)
        {
            throw new CustomBasicException("Colors must start with FF so no transparency");
        }
        string output = $"#{color.Substring(3, 6)}";
        return output;
    }
    public static void PopulateCircle(this Circle circle, float x, float y, float widthHeight, string customColor, double opacity = 1)
    {
        var value = (widthHeight / 2) + x;
        circle.CX = value.ToString();
        value = (widthHeight / 2) + y;
        circle.CY = value.ToString();
        circle.R = (widthHeight / 2).ToString();
        if (customColor != "")
        {
            circle.Fill = customColor.ToWebColor();
        }
        circle.Fill_Opacity = opacity.ToString();
    }
    public static void PopulateCircle(this Circle circle, RectangleF rectangle, string customColor, double opacity = 1)
    {
        circle.PopulateCircle(rectangle.X, rectangle.Y, rectangle.Width, customColor, opacity);
    }
    public static void PopulateRectangle(this Rect rect, RectangleF rectangle)
    {
        rect.X = rectangle.X.ToString();
        rect.Y = rectangle.Y.ToString();
        rect.Width = rectangle.Width.ToString();
        rect.Height = rectangle.Height.ToString();
    }
    public static void PopulateRectangle(this Rect rect, float x, float y, float width, float height)
    {
        rect.PopulateRectangle(new RectangleF(x, y, width, height));
    }
    public static void PopulateEllipse(this Ellipse ellipse, RectangleF rectangle)
    {
        var value = (rectangle.Width / 2) + rectangle.X;
        ellipse.CX = value.ToString();
        value = (rectangle.Height / 2) + rectangle.Y;
        ellipse.CY = value.ToString();
        ellipse.RX = (rectangle.Width / 2).ToString();
        ellipse.RY = (rectangle.Height / 2).ToString();
    }
    public static void Rotate180Degrees(this G g, RectangleF rectangle)
    {
        float x;
        float y;
        x = rectangle.Width + (rectangle.X * 2);
        y = rectangle.Height + (rectangle.Y * 2);
        g.Transform = $"translate({x}, {y}) rotate(180)";
    }
    public static void PopulateSVGStartingPoint(this ISvg svg, RectangleF rectangle)
    {
        svg.X = rectangle.X.ToString();
        svg.Y = rectangle.Y.ToString();
        svg.Width = rectangle.Width.ToString();
        svg.Height = rectangle.Height.ToString();
    }
    public static void DrawCenteredText(this IParentGraphic parent, RectangleF rectangle, float fontSize, string text, string customColor)
    {
        Text tt = new();
        ISvg svg = new SVG();
        svg.PopulateSVGStartingPoint(rectangle);
        parent.Children.Add(svg);
        tt.CenterText();
        tt.Font_Size = fontSize;
        tt.Fill = customColor.ToWebColor();
        svg.Children.Add(tt);
        tt.Content = text;
    }
    public static void DrawLine(this IParentGraphic parent, PointF firstPoint, PointF secondPoint, string color, float strokeWidth, double opacity = 1)
    {
        Line line = new();
        line.X1 = firstPoint.X.ToString();
        line.Y1 = firstPoint.Y.ToString();
        line.X2 = secondPoint.X.ToString();
        line.Y2 = secondPoint.Y.ToString();
        line.PopulateStrokesToStyles(color, strokeWidth, opacity: opacity);
        parent.Children.Add(line);
    }
    private static string GetPoints(this BasicList<PointF> points)
    {
        StrCat cats = new();
        points.ForEach(x => cats.AddToString($"{x.X}, {x.Y}", " "));
        return cats.GetInfo();
    }
    public static Polygon CreatePolygon(this BasicList<PointF> points)
    {
        Polygon output = new();
        output.Points = points.GetPoints();
        return output;
    }
    public static void PopulateLine(this Line line, PointF firstPoint, PointF secondPoint)
    {
        line.X1 = firstPoint.X.ToString();
        line.Y1 = firstPoint.Y.ToString();
        line.X2 = secondPoint.X.ToString();
        line.Y2 = secondPoint.Y.ToString();
    }
}