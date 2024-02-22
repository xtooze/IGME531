using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Generator
{
    public class Toolbox4
    {
        private DrawFunctions df;
        private Random rng;
        private float[,] noiseNums;

        public Toolbox4(DrawFunctions df, Random rng, float[,] noiseNums)
        {
            this.df = df;
            this.rng = rng;
            this.noiseNums = noiseNums;
        }

        public string DrawInteruptionsBasic()
        {
            string interuptions = "";

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (noiseNums[i, j] > .3)
                    {
                        continue;
                    }
                    interuptions += df.rotate(df.drawLine("black", i, j, i + 2, j), rng.Next(0, 360), (i + i + 2) / 2, j);
                }
            }

            return interuptions;
        }

        public string DrawInteruptionsUniformLean()
        {
            string interuptions = "";

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (noiseNums[i, j] > .3)
                    {
                        continue;
                    }
                    df.rotate(df.drawLine($"rgb({0},{0},{0})", i, j, i + 2, j), 360 * noiseNums[i, j], (i + i + 2) / 2, j);
                }
            }

            return interuptions;
        }
    }
}

