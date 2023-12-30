
using Utils;

namespace Graphics;
public class PixelsMatrix:IPixelsMatrix
{
    public int NCharactersPixel { get; private set; }
    public PixelsMatrix(Point2 dimension, int nCharactersPixel):base (dimension)
    {
        this.NCharactersPixel = nCharactersPixel;
    }
    public override bool FillWith(string data){
        if (data.Length > this.NCharactersPixel) return false;
        for (int y = 0; y < this.Dimension.y; y++)
            for (int x = 0; x < this.Dimension.x; x++)
                if (!this.SetElement(new(x, y), new(data))) return false;
        return true;
    }
    public override bool SetPixel(Point2 p, Pixel data)
    {
        if (data is null) return false;
        if (data.Value.Length > this.NCharactersPixel) return false;
        return SetElement(p, data);
    }
    public override Pixel GetPixel(Point2 p) => GetElement(p) ?? new Pixel(" ");
    public override IEnumerable<Pixel>? GetLine(int y)
    {
        if (y > this.Dimension.y) yield return new("x");
        for(var x=0;x<this.Dimension.x;x++){
            yield return GetPixel(new(x,y));
        }   
    }
}