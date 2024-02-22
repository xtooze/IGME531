using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Generator
{
    public class Toolbox3
    {
        private DrawFunctions df;

        public Toolbox3(DrawFunctions df)
        {
            this.df = df;
        }

        public string DrawSchotter()
        {
            string schotter = "";

            for (int j = 0; j < 24; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    schotterRect(df, 0 + (i * 10), 0 + (j * 10), 10, 10, (double)i, (double)j);
                }
            }

            return schotter;
        }

        string schotterRect(DrawFunctions df, double x, double y, double width, double height, double i, double j)
        {
            Random rng = new Random();
            string rect = df.drawRect("black", "none", x, y, width, height, 0);
            rect = df.rotate(rect, rng.NextDouble() * (45 * (j / 23)), x + width / 2, y + height / 2);
            rect = df.translate(rect, rng.NextDouble() * (10 * (j / 23) - -10 * (j / 23)) + -10 * (j / 23), rng.NextDouble() * (20 * (j / 23) - -20 * (j / 23)) + -10 * (j / 23));
            return rect;
        }
    }
}

