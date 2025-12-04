namespace SvgHelper.Blazor.Logic;
public static class Extensions
{
    extension (IStart start)
    {
        public void AutoIncrementElement(IParentContainer parent)
        {
            start.RenderUpTo = parent.ManuelUpTo;
            parent.ManuelUpTo++;
        }
    }
    extension (Image image)
    {
        public void PopulateBasicExternalImage(string name)
        {
            string text = ff2.GetFile(name);
            image.Href = text;
        }
        public void PopulateImagePositionings(RectangleF rect)
        {
            image.Width = rect.Width.ToString();
            image.Height = rect.Height.ToString();
            image.X = rect.X.ToString();
            image.Y = rect.Y.ToString();
        }
        public void PopulateImagePositionings(Rect rect)
        {
            image.Width = rect.Width;
            image.Height = rect.Height;
            image.X = rect.X;
            image.Y = rect.Y;
        }
        public void PopulateImagePositionings(float x, float y, float width, float height)
        {
            image.Width = width.ToString();
            image.Height = height.ToString();
            image.X = x.ToString();
            image.Y = y.ToString();
        }
    }
    extension (BaseElement element)
    {
        public void PopulateStrokesToStyles(string color = "black", float strokeWidth = 1, string fontFamily = "default", double opacity = 1)
        {
            if (fontFamily == "default")
            {
                fontFamily = TextFontHelpers.BorderedTextFontFamily; //do here.  for now, only for doing strokes to styles.
            }
            element.Style = $"stroke: {color}; stroke-width: {strokeWidth}px; stroke-miterlimit:4; font-family:{fontFamily}; opacity: {opacity}";
        }
    }
    extension (Text text)
    {
        public void PopulateTextFont(string fontFamily = "Lato")
        {
            text.Style = $"font-family:{fontFamily};";
        }
        public void CenterText(IParentGraphic parent, RectangleF rect)
        {
            text.CenterText(parent, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void CenterText(IParentGraphic parent, Rect rect)
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
        public void CenterText(IParentGraphic parent, float x, float y, float width, float height)
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
        public void CenterText()
        {
            text.Width = "100%";
            text.Height = "100%";
            text.X = "50%";
            text.Y = "55%";
            text.Dominant_Baseline = "middle";
            text.Text_Anchor = "middle";
        }
    }
    extension (IImageSize image)
    {
        public void PopulateImageSize(Size size)
        {
            image.Width = size.Width.ToString();
            image.Height = size.Height.ToString();
        }
        public void PopulateImageSize(double width, double height)
        {
            image.Width = width.ToString();
            image.Height = height.ToString();
        }

    }
    extension (string color)
    {
        public string ColorUsed
        {
            get
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
        }
    }
    extension (Circle circle)
    {
        public void PopulateCircle(float x, float y, float radius, string customColor, double opacity = 1)
        {
            var value = radius + x;
            circle.CX = value.ToString();
            value = radius + y;
            circle.CY = value.ToString();
            circle.R = radius.ToString();
            if (customColor != "")
            {
                circle.Fill = customColor.ToWebColor;
            }
            circle.Fill_Opacity = opacity.ToString();
        }
        public void PopulateCircle(RectangleF rectangle, string customColor, double opacity = 1)
        {
            circle.PopulateCircle(rectangle.X, rectangle.Y, rectangle.Width / 2, customColor, opacity);
        }

    }
    extension (Rect rect)
    {
        public void PopulateRectangle(RectangleF rectangle)
        {
            rect.X = rectangle.X.ToString();
            rect.Y = rectangle.Y.ToString();
            rect.Width = rectangle.Width.ToString();
            rect.Height = rectangle.Height.ToString();
        }
        public void PopulateRectangle(float x, float y, float width, float height)
        {
            rect.PopulateRectangle(new RectangleF(x, y, width, height));
        }
    }
    extension (Ellipse ellipse)
    {
        public void PopulateEllipse(float x, float y, float width, float height)
        {
            var value = (width / 2) + x;
            ellipse.CX = value.ToString();
            value = (height / 2) + y;
            ellipse.CY = value.ToString();
            ellipse.RX = (width / 2).ToString();
            ellipse.RY = (height / 2).ToString();
        }
        public void PopulateEllipse(RectangleF rectangle)
        {
            var value = (rectangle.Width / 2) + rectangle.X;
            ellipse.CX = value.ToString();
            value = (rectangle.Height / 2) + rectangle.Y;
            ellipse.CY = value.ToString();
            ellipse.RX = (rectangle.Width / 2).ToString();
            ellipse.RY = (rectangle.Height / 2).ToString();
        }
    }
    extension (G g)
    {
        public void Rotate180Degrees(RectangleF rectangle)
        {
            float x;
            float y;
            x = rectangle.Width + (rectangle.X * 2);
            y = rectangle.Height + (rectangle.Y * 2);
            g.Transform = $"translate({x}, {y}) rotate(180)";
        }
    }
    extension (ISvg svg)
    {
        public void PopulateSVGStartingPoint(RectangleF rectangle)
        {
            svg.X = rectangle.X.ToString();
            svg.Y = rectangle.Y.ToString();
            svg.Width = rectangle.Width.ToString();
            svg.Height = rectangle.Height.ToString();
        }
    }
    extension (IParentGraphic parent)
    {
        public void DrawCenteredText(RectangleF rectangle, float fontSize, string text, string customColor)
        {
            Text tt = new();
            ISvg svg = new SVG();
            svg.PopulateSVGStartingPoint(rectangle);
            parent.Children.Add(svg);
            tt.CenterText();
            tt.Font_Size = fontSize;
            tt.Fill = customColor.ToWebColor;
            svg.Children.Add(tt);
            tt.Content = text;
        }
        public void DrawLine(PointF firstPoint, PointF secondPoint, string color, float strokeWidth, double opacity = 1)
        {
            Line line = new();
            line.X1 = firstPoint.X.ToString();
            line.Y1 = firstPoint.Y.ToString();
            line.X2 = secondPoint.X.ToString();
            line.Y2 = secondPoint.Y.ToString();
            line.PopulateStrokesToStyles(color, strokeWidth, opacity: opacity);
            parent.Children.Add(line);
        }
    }
    extension(BasicList<PointF> points)
    {
        private string GetPoints()
        {
            StrCat cats = new();
            points.ForEach(x => cats.AddToString($"{x.X}, {x.Y}", " "));
            return cats.GetInfo();
        }
        public Polygon CreatePolygon()
        {
            Polygon output = new();
            output.Points = points.GetPoints();
            return output;
        }
    }
    extension(Line line)
    {
        public void PopulateLine(float x1, float y1, float x2, float y2)
        {
            line.X1 = x1.ToString();
            line.Y1 = y1.ToString();
            line.X2 = x2.ToString();
            line.Y2 = y2.ToString();
        }
    }
}