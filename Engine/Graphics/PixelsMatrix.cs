
using Utils;

namespace Graphics;
public class PixelsMatrix: Matrix<Pixel>
{
    public int NCharactersPixel { get; private set; }
    public PixelsMatrix(Point2 dimension, int nCharactersPixel):base (dimension,new(" "))
    {
        this.NCharactersPixel = nCharactersPixel;
    }
    public bool FillWith(string data){
        if (data.Length > this.NCharactersPixel) return false;
        for (int y = 0; y < this.Dimension.y; y++)
            for (int x = 0; x < this.Dimension.x; x++)
                if (!this.SetElement(new(x, y), new(data))) return false;
        return true;
    }
    public bool SetPixel(Point2 p, Pixel data)
    {
        if (data is null) return false;
        if (data.Value.Length > this.NCharactersPixel) return false;
        return SetElement(p, data);
    }
    public void SetMatrix( Dictionary<Point2, Pixel> matrix){
        Elements = matrix;
    }
    public Pixel GetPixel(Point2 p) => GetElement(p) ?? new Pixel(" ");
    public IEnumerable<Pixel>? GetLine(int y)
    {
        if (y > this.Dimension.y) yield return new("x");
        for(var x=0;x<this.Dimension.x;x++){
            yield return GetPixel(new(x,y));
        }   
    }
    public PixelsMatrix GetPixelMatrixRotatedOf90(){
        var tMatrix = new PixelsMatrix(new(Dimension.y, Dimension.x),NCharactersPixel);
        tMatrix.Elements = GetMatrixWithRotationOf90();
        return tMatrix;
    }
    public void DeletePixel(Point2 p)=>this.DeleteElement(p);
}