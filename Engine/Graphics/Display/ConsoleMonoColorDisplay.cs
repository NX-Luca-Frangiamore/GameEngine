using Graphics;
using Utils;

namespace Graphics.Display;
public class ConsoleMonoColorDisplay:IDisplay
{
    public ConsoleMonoColorDisplay(Point2 dimension):base(dimension)
    {    }

    public override void NewLine()
    {
        Console.WriteLine();
    }

    public override void PrintPixelOnSameLine(Pixel pixel)
    {
        Console.Write(pixel.Value);
    }
}
