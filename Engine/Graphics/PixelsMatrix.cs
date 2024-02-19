
using Utils;

namespace Graphics;
public class PixelsMatrix: Matrix<Pixel>
{
    public int NCharactersPixel { get; private set; }
    public PixelsMatrix(Point2 dimension, int nCharactersPixel):base (dimension,new(" "))
    {
        this.NCharactersPixel = nCharactersPixel;
    }

    public PixelsMatrix(Point2 dimension) : this(dimension, 1) { }
    
    public PixelsMatrix(Point2 dimension, Dictionary<Point2, Pixel> elemets) : base(dimension,new(" "), elemets) { }
    public bool FillWith(string data){
        if (data.Length > this.NCharactersPixel) return false;
        for (int y = 0; y < this.Dimension.y; y++)
            for (int x = 0; x < this.Dimension.x; x++)
                if (!this.SetElement(new(x, y), new(data))) return false;
        return true;
    }
    public Pixel GetPixel(Point2 p) => GetElement(p) ?? new Pixel(" ");
    public bool SetPixel(Point2 p, Pixel v) => SetElement(p, v);
    public PixelsMatrix Clone()
    {
        var t = new PixelsMatrix(Dimension);
        t.SetElements(Elements); return t;
    }
    public IEnumerable<Pixel>? GetLine(int y)
    {
        if (y > this.Dimension.y) yield return new("x");
        for(var x=0;x<this.Dimension.x;x++){
            yield return GetPixel(new(x,y));
        }   
    }
}