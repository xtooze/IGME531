using System;

namespace SVG_Generator
{
    public class DrawFunctions
    {
        public string drawRect(string stroke, string fill, double x, double y, double width, double height, double angle)
        {
            return $"<rect stroke=\"{stroke}\" fill=\"{fill}\" x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" transform=\"rotate({angle},{x + width / 2},{y + height / 2})\"></rect>";
        }

        public string drawCircle(string stroke, string fill, double cx, double cy, double r)
        {
            return $"<circle stroke=\"{stroke}\" fill=\"{fill}\" cx=\"{cx}\" cy=\"{cy}\" r=\"{r}\"></circle>";
        }

        public string drawEllipse(string stroke, string fill, double cx, double cy, double rx, double ry, double angle)
        {
            return $"<ellipse stroke=\"{stroke}\" fill=\"{fill}\" cx=\"{cx}\" cy=\"{cy}\" rx=\"{rx}\" ry=\"{rx}\" transform=\"rotate({angle},{cx + rx / 2},{cy + ry / 2})\"></ellipse>";
        }

        public string drawLine(string stroke, double x1, double y1, double x2, double y2)
        {
            return $"<line stroke=\"{stroke}\" x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke-width=\".05\"></line>";
        }

        public string drawPolygon(string stroke, string fill, double[] points)
        {
            string pointsString = "";
            for (int i = 0; i < points.Length; i++)
            {
                pointsString += points[i].ToString();
                if (i % 2 == 0)
                {
                    pointsString += ",";
                }
                else
                {
                    pointsString += " ";
                }
            }
            return $"<polygon stroke=\"{stroke}\" fill=\"{fill}\" points=\"{pointsString}\"></polygon>";
        }

        public string drawPolyline(string stroke, string fill, double[] points)
        {
            string pointsString = "";
            for (int i = 0; i < points.Length; i++)
            {
                pointsString += points[i].ToString();
                if (i % 2 == 0)
                {
                    pointsString += ",";
                }
                else
                {
                    pointsString += " ";
                }
            }
            return $"<polyline stroke=\"{stroke}\" fill=\"{fill}\" points=\"{pointsString}\" stroke-width=\".05\"></polyline>";
        }

        public string drawPath(string stroke, string fill, string commands)
        {
            return $"<path stroke=\"{stroke}\" fill=\"{fill}\" d={commands}></path>";
        }

        public string group(string shape)
        {
            return $"<g>{shape}</g>";
        }

        public string translate(string shape, double x, double y)
        {
            return $"<g transform=\"translate({x} {y})\">{shape}</g>";
        }

        public string rotate(string shape, double angle, double x, double y)
        {
            return $"<g transform=\"rotate({angle} {x} {y})\">{shape}</g>";
        }

        public string scale(string shape, double x, double y)
        {
            return $"<g transform=\"scale({x} {y})\">{shape}</g>";
        }

        public DrawFunctions()
        {
        }
    }
}
