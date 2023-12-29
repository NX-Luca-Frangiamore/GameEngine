using Graphics;
using Utils;

namespace GraphicsEngine;
public abstract class IDisplay{
    public Point2 Dimension{ get; protected set; }
    public IDisplay(Point2 dimension){
        this.Dimension = dimension;
    }
    public abstract void ShowFrame(PixelsMatrix frame);
    public abstract void ShowEmptyFrame();
}
public class Display:IDisplay
{
    public Display(Point2 dimension):base(dimension)
    {    }
    
    public override void ShowFrame(PixelsMatrix frame)
    {
        if(frame is null){
            Console.WriteLine("nessuna matrice caricata");
            return;
        }
        Console.WriteLine();
        this.PrintFrame(frame);
        Console.WriteLine(); 
    }

    public override void ShowEmptyFrame(){
        for(int y=0;y<this.Dimension.y;y++)
            Console.WriteLine();
    }

    private void PrintFrame(PixelsMatrix matrix){
        for (int y = matrix.Dimension.y-1; y >=0; y--)
        {
            foreach (string? point in TransformLookLine(matrix.GetLine(y)!))
            {
                Console.Write(point);
            }
            Console.WriteLine();
        }
    }

    private IEnumerable<string> TransformLookLine(IEnumerable<string> line){
       yield return $"|{line.First()}|";
       foreach(var point in line.Skip(1))
                yield return $"{point}|";
    }
}
