
using Graphics.Display;
using Object;
using Utils;

namespace Graphics.GraphicsEngine;


public class ColorGraphicsEngine : IGraphicsEngine
{ 
    
    public ColorGraphicsEngine(IDisplay display) : base(display)
    {
    }
    public override void ShowEmptyFrame()=> this.Display.ShowEmptyFrame();
    public override void ShowFrame(List<DtoGraphicsEngine> sprites)
    {
        this.Display.ShowEmptyFrame();
        PixelsMatrix newMatrix= new(Display.Dimension,1);
        foreach (var o in sprites) { 
            if (!o.Sprite.IsVisible) continue;
            for (int y = 0; y < o.Sprite.Dimension.y; y++)
                for (int x = 0; x < o.Sprite.Dimension.x; x++)
                {
                    Point2 pixelPosition = new(x, y);
                    newMatrix.SetPixel(o.AbsolutePosition.Plus(pixelPosition.Plus(o.Sprite.Position)),
                         o.Sprite.GetPixel(pixelPosition));
                }
        }
        this.PrintFrame(newMatrix);
    }
    public void PrintFrame(PixelsMatrix frame)
    {
        Pixel tPixel;
        Pixel marcherPixel = new("|");
        Display.NewLine();
        for (int y = this.Display.Dimension.y-1; y>=0; y--)
        {
            tPixel = frame.GetPixel(new(0, y));
            Display.PrintPixelOnSameLine(marcherPixel);
            Display.PrintPixelOnSameLine(tPixel);
            Display.PrintPixelOnSameLine(marcherPixel);
            for (int x = 1; x < this.Display.Dimension.x; x++)
            {
                tPixel = frame.GetPixel(new(x, y));
                Display.PrintPixelOnSameLine(tPixel);
                Display.PrintPixelOnSameLine(marcherPixel);
            }
            Display.NewLine();
        }
        Display.NewLine();
        Display.FinishPrintFrame();

    }

}