using System.ComponentModel;
using System.Reflection.Metadata;

namespace Utils;
public class PixelsMatrix:Matrix<String>
{
    public int NCharactersPixel { get; private set; }
    public PixelsMatrix(Vector2 dimension, int nCharactersPixel):base (dimension)
    {
        this.NCharactersPixel = nCharactersPixel;
    }
    public bool FillWith(string data){
        if (data.Length > this.NCharactersPixel) return false;
        for (int y = 0; y < this.Dimension.y; y++)
            for (int x = 0; x < this.Dimension.x; x++)
                if (!this.Set(new(x, y), data)) return false;
        return true;
    }
    public bool SetPixel(Vector2 p, string data)
    {
        if (data.Length > this.NCharactersPixel) return false;
        return Set(p, data);
    }
    public void DeletePixel(Vector2 p)=>this.Delete(p);
    public string GetPixel(Vector2 p) => Get(p) ?? new string(' ', NCharactersPixel);
    public IEnumerable<string>? GetLine(int y)
    {
        if (y > this.Dimension.y) yield return "x";
        for(var x=0;x<this.Dimension.x;x++){
            yield return GetPixel(new(x,y));
        }   
    }
}