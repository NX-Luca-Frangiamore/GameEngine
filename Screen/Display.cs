using Utils;
namespace Screen;
public class Display
{
    private int NCharactersPoint;
    private PixelsMatrix? Frame;
    public Vector2 Dimension{ get; private set;}
    
    public Display(Vector2 dimension,int nCharactersPoint)
    {
        this.NCharactersPoint = nCharactersPoint;
        this.Dimension = dimension;
    }
    
    public PixelsMatrix NewEmptyFrame(){
        return new PixelsMatrix(Dimension, NCharactersPoint);
    }
    
    public void SetFrame(PixelsMatrix matrix){
        if(matrix.Dimension==this.Dimension)
            this.Frame = matrix;
    }

    public void ShowFrame()
    {
        if(this.Frame is null){
            Console.WriteLine("nessuna matrice caricata");
            return;
        }
        Console.WriteLine();
        this.PrintFrame(this.Frame);
        Console.WriteLine(); 
    }

    public void ShowEmptyFrame(){
        Console.WriteLine();
        this.PrintFrame(this.NewEmptyFrame());
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
