using Graphics;
using Utils;

namespace Graphics.Display;
public class ConsoleMonoColorDisplay:IDisplay
{
    public ConsoleMonoColorDisplay()
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
