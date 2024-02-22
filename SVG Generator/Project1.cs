using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Generator
{
    public class Project1
    {
        private DrawFunctions df;
        private Random rng;

        public Project1(DrawFunctions df, Random rng) 
        {
            this.df = df;
            this.rng = rng;
        }

        public string drawTile(DrawFunctions df, double tileWidth, double tileHeight, int boundMax)
        {
            string tileGrid = "";
            for (double i = 0; i < 100; i += tileWidth)
            {
                for (double j = 0; j < 100; j += tileHeight)
                {
                    switch (rng.Next(0, 4))
                    {
                        case 0:
                            tileGrid += tileCurve(df, i, j, tileWidth, tileHeight, rng.Next(0, boundMax), rng.Next(0, boundMax));
                            break;
                        case 1:
                            tileGrid += df.rotate(tileCurve(df, i, j, tileWidth, tileHeight, rng.Next(0, boundMax), rng.Next(0, boundMax)), 90, i + tileWidth / 2, j + tileHeight / 2);
                            break;
                        case 2:
                            tileGrid += df.rotate(tileCurve(df, i, j, tileWidth, tileHeight, rng.Next(0, boundMax), rng.Next(0, boundMax)), 180, i + tileWidth / 2, j + tileHeight / 2);
                            break;
                        case 3:
                            tileGrid += df.rotate(tileCurve(df, i, j, tileWidth, tileHeight, rng.Next(0, boundMax), rng.Next(0, boundMax)), 270, i + tileWidth / 2, j + tileHeight / 2);
                            break;
                    }
                }
            }
            return tileGrid;
        }

        string tileCurve(DrawFunctions df, double x, double y, double width, double height, int upperNum, int lowerNum)
        {
            string tile = "";
            for (int i = 2; i < upperNum + 2; i++)
            {
                if (i == 2)
                {
                    tile += df.drawLine("black", x, y + height / i, x + width / i, y);
                }
                else
                {
                    tile += df.drawLine("red", x, y + height / i, x + width / i, y);
                }
            }
            for (int i = 2; i < lowerNum + 2; i++)
            {
                if (i == 2)
                {
                    tile += df.drawLine("black", x + width / i, y + height, x + width, y + height / i);
                }
                else
                {
                    tile += df.drawLine("red", x + width / i, y + height, x + width, y + height / i);
                }
            }
            return tile;
        }
    }
}
