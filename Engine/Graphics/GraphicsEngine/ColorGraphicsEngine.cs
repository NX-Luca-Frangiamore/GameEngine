
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
        PixelsMatrix newMatrix= new(Display.Dimension,1);
        foreach (var o in sprites)
            for (int y = 0; y < o.Sprite.Dimension.y; y++)
                for (int x = 0; x < o.Sprite.Dimension.x; x++)
                {
                    Point2 pixelPosition = new(x, y);
                    newMatrix.SetPixel(o.AbsolutePosition.Plus(pixelPosition.Plus(o.Sprite.Position)),
                         o.Sprite.Data.GetPixel(pixelPosition));
                }
        Display.NewLine();
        this.PrintFrame(newMatrix);
        Display.NewLine(); 
    }
    public void PrintFrame(IPixelsMatrix frame)
    {
        Pixel tPixel;
        Pixel marcherPixel = new("|", new() { Color = "white" });
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

    }

}