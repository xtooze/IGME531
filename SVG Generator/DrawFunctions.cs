using System;

namespace SVGGenerator
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
            return $"<line stroke=\"{stroke}\" x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\"></line>";
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

        public DrawFunctions()
        {
        }
    }
}
