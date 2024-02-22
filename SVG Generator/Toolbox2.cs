using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Generator
{
    public class Toolbox2
    {
        private DrawFunctions df;

        public Toolbox2(DrawFunctions df)
        {
            this.df = df;
        }

        public string DrawDesOrdes()
        {
            string desOrdes = "";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    desOrdes += desOrdesSquare(df, 0 + (j * 10), 0 + (i * 10), 10, 10, .15);
                    //desOrdes += desOrdesSpiral(df, 0 + (j * 10), 0 + (i * 10), 10, 10, .2);
                }
            }

            return desOrdes;
        }

        string desOrdesSquare(DrawFunctions df, double x, double y, double width, double height, double variance)
        {
            Random rng = new Random();
            int numSquares = rng.Next(5, 15);
            string squares = "";
            double cx = x + width / 2;
            double cy = y + height / 2;
            double[] points = new double[10];
            double[] lastPoints = new double[10];
            points[0] = rng.NextDouble() * (cx - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[1] = rng.NextDouble() * (cy - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[2] = rng.NextDouble() * (width + x - cx) + cx + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[3] = rng.NextDouble() * (cy - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[4] = rng.NextDouble() * (width + x - cx) + cx + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[5] = rng.NextDouble() * (height + y - cy) + cy + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[6] = rng.NextDouble() * (cx - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[7] = rng.NextDouble() * (height + y - cy) + cy + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[8] = points[0];
            points[9] = points[1];
            squares += df.drawPolyline("black", "none", points);
            for (int j = 0; j < points.Length; j++)
            {
                lastPoints[j] = points[j];
            }
            for (int i = 2; i <= numSquares; i++)
            {
                points[0] = rng.NextDouble() * (lastPoints[0] - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[1] = rng.NextDouble() * (lastPoints[1] - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[0]},{points[1]}");
                points[2] = rng.NextDouble() * (width + x - lastPoints[2]) + lastPoints[2] + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[3] = rng.NextDouble() * (lastPoints[3] - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[2]},{points[3]}");
                points[4] = rng.NextDouble() * (width + x - lastPoints[4]) + lastPoints[4] + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[5] = rng.NextDouble() * (height + y - lastPoints[5]) + lastPoints[5] + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[4]},{points[5]}");
                points[6] = rng.NextDouble() * (lastPoints[6] - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[7] = rng.NextDouble() * (height + y - lastPoints[7]) + lastPoints[7] + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[6]},{points[7]}");
                points[8] = points[0];
                points[9] = points[1];
                squares += df.drawPolyline("black", "none", points);
                for (int j = 0; j < points.Length; j++)
                {
                    lastPoints[j] = points[j];
                }
                Console.WriteLine();
            }
            return df.group(squares);
        }

        string desOrdesSpiral(DrawFunctions df, double x, double y, double width, double height, double variance)
        {
            Random rng = new Random();
            int numSquares = rng.Next(5, 15);
            double[] allPoints = new double[numSquares * 8];
            string squares = "";
            double cx = x + width / 2;
            double cy = y + height / 2;
            double[] points = new double[8];
            double[] lastPoints = new double[8];
            points[0] = rng.NextDouble() * (cx - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[1] = rng.NextDouble() * (cy - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[2] = rng.NextDouble() * (width + x - cx) + cx + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[3] = rng.NextDouble() * (cy - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[4] = rng.NextDouble() * (width + x - cx) + cx + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[5] = rng.NextDouble() * (height + y - cy) + cy + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            points[6] = rng.NextDouble() * (cx - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
            points[7] = rng.NextDouble() * (height + y - cy) + cy + (rng.NextDouble() * (variance * height + variance * height - variance * height));
            for (int j = 0; j < points.Length; j++)
            {
                lastPoints[j] = points[j];
                allPoints[j] = points[j];
            }
            for (int i = 2; i <= numSquares; i++)
            {
                points[0] = rng.NextDouble() * (lastPoints[0] - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[1] = rng.NextDouble() * (lastPoints[1] - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[0]},{points[1]}");
                points[2] = rng.NextDouble() * (width + x - lastPoints[2]) + lastPoints[2] + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[3] = rng.NextDouble() * (lastPoints[3] - y) + y + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[2]},{points[3]}");
                points[4] = rng.NextDouble() * (width + x - lastPoints[4]) + lastPoints[4] + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[5] = rng.NextDouble() * (height + y - lastPoints[5]) + lastPoints[5] + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[4]},{points[5]}");
                points[6] = rng.NextDouble() * (lastPoints[6] - x) + x + (rng.NextDouble() * (variance * width + variance * width - variance * width));
                points[7] = rng.NextDouble() * (height + y - lastPoints[7]) + lastPoints[7] + (rng.NextDouble() * (variance * height + variance * height - variance * height));
                Console.WriteLine($"{points[6]},{points[7]}");
                for (int j = 0; j < points.Length; j++)
                {
                    lastPoints[j] = points[j];
                    allPoints[j + (i - 1) * 8] = points[j];
                }
            }
            squares += df.drawPolyline("black", "none", allPoints);
            return df.group(squares);
        }
    }
}
    
