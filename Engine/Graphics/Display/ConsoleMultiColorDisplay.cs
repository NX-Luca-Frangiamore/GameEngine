using System.Text;
using Graphics.Display;
using Utils;

class ConsoleMulticolorDisplay : IDisplay
{
    StringBuilder Buffer=new();
    ConsoleColor? lastColor=null;
    const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;

    public override void NewLine() => Buffer.AppendLine();

    public override void PrintPixelOnSameLine(Pixel pixel)
    {
        if (GetColorFrom(pixel) != lastColor && lastColor is not null){
            Console.ForegroundColor =(ConsoleColor)lastColor;
            var a = Buffer.ToString();
            Console.Write(Buffer);
            Buffer.Clear();
        }
        Buffer.Append(pixel.Value);
        lastColor = GetColorFrom(pixel);
    }
    private ConsoleColor GetColorFrom(Pixel pixel) => Enum.TryParse(pixel.Info?.Color??" ", true, out ConsoleColor c) ? c : DEFAULT_COLOR;

    public override void ShowEmptyFrame() { Buffer.Clear(); Console.Clear(); }

    public override void FinishPrintFrame()
    {
        Console.ForegroundColor =(ConsoleColor)lastColor!;
        Console.Write(Buffer);
        Buffer.Clear();
        lastColor = null;
    }
}