using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Generator
{
    public class Toolbox1
    {
        private DrawFunctions df;

        public Toolbox1(DrawFunctions df)
        {
            this.df = df;
        }

        public string DrawSainteVictoire()
        {
            string saintVictoire = "";
            saintVictoire += df.drawRect("#BE2A2A", "#BE2A2A", 1, 35, 20, 20, 5);
            saintVictoire += df.drawRect("#6B2933", "#6B2933", 12, 7, 20, 20, -20);
            saintVictoire += df.drawRect("#BE2A2A", "#BE2A2A", 25, 7, 20, 20, -5);
            saintVictoire += df.drawRect("#6B2933", "#6B2933", 54, 42, 20, 20, 5);
            saintVictoire += df.drawRect("#6B2933", "#6B2933", 43, 43, 20, 20, -20);
            saintVictoire += df.drawRect("#BE2A2A", "#BE2A2A", 55, 58, 20, 20, 43);
            saintVictoire += df.drawRect("#E52523", "#E52523", 65, 60, 20, 20, 20);
            saintVictoire += df.drawRect("#E84139", "#E84139", 12, 20, 20, 20, 43);
            saintVictoire += df.drawRect("#E84139", "#E84139", 40, 23, 20, 20, -10);
            saintVictoire += df.drawCircle("#BE2A2A", "#BE2A2A", 11, 45, 12);
            saintVictoire += df.drawCircle("#6B2933", "#6B2933", 22, 17, 12);
            saintVictoire += df.drawCircle("#BE2A2A", "#BE2A2A", 35, 17, 12);
            saintVictoire += df.drawCircle("#6B2933", "#6B2933", 64, 52, 12);
            saintVictoire += df.drawCircle("#6B2933", "#6B2933", 53, 53, 12);
            saintVictoire += df.drawCircle("#BE2A2A", "#BE2A2A", 65, 68, 12);
            saintVictoire += df.drawCircle("#E52523", "#E52523", 75, 70, 12);
            saintVictoire += df.drawCircle("#E84139", "#E84139", 22, 30, 12);
            saintVictoire += df.drawCircle("#E84139", "#E84139", 50, 33, 12);
            return saintVictoire;
        }
    }
}
