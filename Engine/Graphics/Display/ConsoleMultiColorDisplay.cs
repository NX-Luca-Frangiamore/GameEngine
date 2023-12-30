using Graphics.Display;
using Utils;

class ConsoleMulticolorDisplay : IDisplay
{
    const ConsoleColor DEFAULT_COLOR = ConsoleColor.Green;
    public ConsoleMulticolorDisplay(Point2 dimension) : base(dimension)
    {
    }

    public override void NewLine()=>Console.WriteLine();

    public override void PrintPixelOnSameLine(Pixel pixel)
    {
        Console.ForegroundColor = GetColorPixel(pixel);
        Console.Write(pixel.Value);
        Console.ForegroundColor = DEFAULT_COLOR;
    }

    private ConsoleColor GetColorPixel(Pixel pixel) => Enum.TryParse(pixel.Info?.Color??" ", true, out ConsoleColor c) ? c : DEFAULT_COLOR;


   
}