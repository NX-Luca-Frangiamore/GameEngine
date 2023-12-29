
using Graphics;
using Object;
using PhysicsEngine;
using Utils;

namespace GraphicsEngine;
public abstract class IGraphicsEngine{
    public IDisplay Display;
    public abstract void ShowFrame(List<Object.StillObject> sprites);
    public abstract void ShowEmptyFrame();

    public IGraphicsEngine(IDisplay display){
        this.Display = display;
    } 
}

public class ConsoleGraphicsEngine : IGraphicsEngine
{
    public int NCharactersPixel=1;
    public ConsoleGraphicsEngine(IDisplay display) : base(display)
    {
    }

    public override void ShowEmptyFrame()=> this.Display.ShowEmptyFrame();

    public override void ShowFrame(List<Object.StillObject> sprites)
    {
        PixelsMatrix newMatrix= new(Display.Dimension,NCharactersPixel);
        foreach (var o in sprites)
            for (int y = 0; y < o.Skin.Dimension.y; y++)
                for (int x = 0; x < o.Skin.Dimension.x; x++)
                {
                    Point2 pixelPosition = new(x, y);
                    newMatrix.SetPixel(pixelPosition.Plus(o.AbsolutePosition.Plus(o.Skin.Position)),
                         o.Skin.Data?.GetPixel(pixelPosition)??null);
                }
        Display.ShowFrame(newMatrix); 
    }
}