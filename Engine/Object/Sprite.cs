using Graphics;
using Utils;

public class Sprite
{
    public bool IsVisible=true;
    public Point2 Position;
    public PixelsMatrix Data { get; private set; }
    public Sprite(Point2 dimension,Point2 position){
        Position = position;
        Data = new(dimension, 1);
    }
    public void RotateSkinOf90() => Data=Data.GetPixelMatrixRotatedOf90();
}