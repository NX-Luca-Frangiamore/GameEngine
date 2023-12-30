
using Graphics.Display;
using Object;
using Utils;

namespace Graphics.GraphicsEngine;


public class DumbGraphicsEngine : IGraphicsEngine
{
    public int NCharactersPixel=1;
    public DumbGraphicsEngine(IDisplay display) : base(display)
    {
    }

    public override void ShowEmptyFrame()=> this.Display.ShowEmptyFrame();

    public override void ShowFrame(List<DtoGraphicsEngine> dtoSprites)
    {
        PixelsMatrix newMatrix= new(Display.Dimension,NCharactersPixel);
        foreach (var o in dtoSprites)
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

    private void PrintFrame(IPixelsMatrix matrix){
        for (int y = matrix.Dimension.y-1; y >=0; y--)
        {
            foreach (Pixel? pixel in TransformLookLine(matrix.GetLine(y)!))
            {
                Display.PrintPixelOnSameLine(pixel);
            }
            Display.NewLine();
        }
    }

    private IEnumerable<Pixel> TransformLookLine(IEnumerable<Pixel> line){
       yield return new($"|{line.First().Value}|");
       foreach(var point in line.Skip(1))
                yield return new($"{point.Value}|");
    }
}