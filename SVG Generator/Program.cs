using System.IO;
using SVGGenerator;

//WriteSVG(new DrawFunctions(), "../../../Sainte-Victoire en Rouge.svg");
WriteSVG(new DrawFunctions(), "../../../Des Ordes Test.svg");


void WriteSVG(DrawFunctions df, string path)
{
    StreamWriter sw = File.CreateText(path);
    try
    {
        sw.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100%\" height=\"100%\" viewBox=\"0 0 100 100\">");

        //sw.WriteLine(df.drawRect("#BE2A2A", "#BE2A2A", 1, 35, 20, 20, 5));
        //sw.WriteLine(df.drawRect("#6B2933", "#6B2933", 12, 7, 20, 20, -20));
        //sw.WriteLine(df.drawRect("#BE2A2A", "#BE2A2A", 25, 7, 20, 20, -5));
        //sw.WriteLine(df.drawRect("#6B2933", "#6B2933", 54, 42, 20, 20, 5));
        //sw.WriteLine(df.drawRect("#6B2933", "#6B2933", 43, 43, 20, 20, -20));
        //sw.WriteLine(df.drawRect("#BE2A2A", "#BE2A2A", 55, 58, 20, 20, 43));
        //sw.WriteLine(df.drawRect("#E52523", "#E52523", 65, 60, 20, 20, 20));

        //sw.WriteLine(df.drawRect("#E84139", "#E84139", 12, 20, 20, 20, 43));
        //sw.WriteLine(df.drawRect("#E84139", "#E84139", 40, 23, 20, 20, -10));

        //sw.WriteLine(df.drawCircle("#BE2A2A", "#BE2A2A", 11, 45, 12));
        //sw.WriteLine(df.drawCircle("#6B2933", "#6B2933", 22, 17, 12));
        //sw.WriteLine(df.drawCircle("#BE2A2A", "#BE2A2A", 35, 17, 12));
        //sw.WriteLine(df.drawCircle("#6B2933", "#6B2933", 64, 52, 12));
        //sw.WriteLine(df.drawCircle("#6B2933", "#6B2933", 53, 53, 12));
        //sw.WriteLine(df.drawCircle("#BE2A2A", "#BE2A2A", 65, 68, 12));
        //sw.WriteLine(df.drawCircle("#E52523", "#E52523", 75, 70, 12));

        //sw.WriteLine(df.drawCircle("#E84139", "#E84139", 22, 30, 12));
        //sw.WriteLine(df.drawCircle("#E84139", "#E84139", 50, 33, 12));
        sw.WriteLine(desOrdesSquare(df, 10, 10, 10, 10));


        sw.WriteLine("</svg>");
    }
    catch (Exception e)
	{
        Console.WriteLine(e.Message);
	}
	finally 
	{
        sw.Close();
    }
}

string desOrdesSquare(DrawFunctions df, double x, double y, double width, double height)
{
    Random rng = new Random();
    int numSquares = rng.Next(1, 21);
    string squares = "";
    double cx = x + width / 2;
    double cy = y + height / 2;
    for (int i = 1; i == numSquares; i++)
    {
        double[] points = new double[10];
        points[0] = rng.NextDouble() * x;
        points[1] = rng.NextDouble() * y;
        points[2] = rng.NextDouble() * x;
        points[3] = rng.NextDouble() * y;
        points[4] = rng.NextDouble() * x;
        points[5] = rng.NextDouble() * y;
        points[6] = rng.NextDouble() * x;
        points[7] = rng.NextDouble() * y;
        points[8] = points[0];
        points[9] = points[1];
        squares += df.drawPolyline("black", "none", points);
    }
    return df.group(squares);
}