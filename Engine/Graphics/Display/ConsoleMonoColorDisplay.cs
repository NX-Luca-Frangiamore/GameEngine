using System.Text;
using Graphics;
using Utils;

namespace Graphics.Display;
public class ConsoleMonoColorDisplay:IDisplay
{
    StringBuilder Buffer=new();
    public ConsoleMonoColorDisplay()
    {    }

    public override void FinishPrintFrame()
    {
        Console.Write(Buffer);
        Buffer.Clear();
    }
    public override void NewLine() => Buffer.AppendLine();

    public override void PrintPixelOnSameLine(Pixel pixel)=>Buffer.Append(pixel.Value);
    public override void ShowEmptyFrame() { Buffer.Clear(); Console.Clear(); }
}
