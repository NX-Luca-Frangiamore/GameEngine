using Utils;

public abstract class IPixelsMatrix : Matrix<Pixel>
{
    protected IPixelsMatrix(Point2 dimension) : base(dimension,new(" ")){}
    public abstract IEnumerable<Pixel>? GetLine(int y);
    public abstract Pixel GetPixel(Point2 p);
    public abstract bool FillWith(string data);
    public abstract bool SetPixel(Point2 p, Pixel pixel);
    public void DeletePixel(Point2 p)=>this.DeleteElement(p);
}