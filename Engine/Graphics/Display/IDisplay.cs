using Graphics;
using Utils;
namespace Graphics.Display;
public abstract class IDisplay{
    public Point2 Dimension{ get; set; }=new(20,20);

    public void SetDimension(Point2 size)=>this.Dimension = size;
    public abstract void PrintPixelOnSameLine(Pixel pixel);
    public abstract void NewLine();
    public abstract void ShowEmptyFrame();
    public abstract void FinishPrintFrame();
}