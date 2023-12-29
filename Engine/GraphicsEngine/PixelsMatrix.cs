
using Utils;

namespace Graphics;
public class PixelsMatrix:Matrix<String>
{
    public int NCharactersPixel { get; private set; }
    public PixelsMatrix(Point2 dimension, int nCharactersPixel):base (dimension)
    {
        this.NCharactersPixel = nCharactersPixel;
    }
    public bool FillWith(string data){
        if (data.Length > this.NCharactersPixel) return false;
        for (int y = 0; y < this.Dimension.y; y++)
            for (int x = 0; x < this.Dimension.x; x++)
                if (!this.SetElement(new(x, y), data)) return false;
        return true;
    }
    public bool SetPixel(Point2 p, string? data)
    {
        if (data is null) return false;
        if (data.Length > this.NCharactersPixel) return false;
        return SetElement(p, data);
    }
    public void DeletePixel(Point2 p)=>this.DeleteElement(p);
    public string GetPixel(Point2 p) => GetElement(p) ?? new string(' ', NCharactersPixel);
    public IEnumerable<string>? GetLine(int y)
    {
        if (y > this.Dimension.y) yield return "x";
        for(var x=0;x<this.Dimension.x;x++){
            yield return GetPixel(new(x,y));
        }   
    }
}