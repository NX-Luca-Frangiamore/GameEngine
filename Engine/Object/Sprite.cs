using Graphics;
using Utils;

public class Sprite{
    public Point2 Position{ get; set; }
    public PixelsMatrix Data{ get; set; }
    public Sprite(Point2 dimension,Point2 position){
        this.Position = position;
        this.Data = new(dimension, 1);
        Data.FillWith("*");
    }
    public void RotateSkinOf90() => Data = Data.GetPixelMatrixRotatedOf90();
}