using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using SVG_Generator;

Random rng = new Random();
FastNoiseLite noise = new FastNoiseLite();
float[,] noiseNums = noiseSetUp(noise, 100, 100, .05f);

DrawFunctions df = new DrawFunctions();

Toolbox1 t1 = new Toolbox1(df);
Toolbox2 t2 = new Toolbox2(df);
Toolbox3 t3 = new Toolbox3(df);
Toolbox4 t4 = new Toolbox4(df, rng, noiseNums);

Project1 p1 = new Project1(df, rng);

WriteSVG(df, "../../../Project1.svg");

void WriteSVG(DrawFunctions df, string path)
{
    StreamWriter sw = File.CreateText(path);
    try
    {
        sw.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100%\" height=\"100%\" viewBox=\"0 0 100 100\">");

        sw.WriteLine(p1.drawTile(df,4,4,4));

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



float[,] noiseSetUp(FastNoiseLite noise, int x, int y, float f)
{
    int seed = rng.Next(int.MinValue, int.MaxValue);
    Console.WriteLine(seed);
    noise.SetSeed(seed);
    noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
    noise.SetFrequency(f);

    float[,] noiseData = new float[x, y];

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            noiseData[i, j] = noise.GetNoise(i, j);
        }
    }

    return noiseData;
}