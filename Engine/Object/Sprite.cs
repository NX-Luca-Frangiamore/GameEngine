using Graphics;
using Utils;

public class Sprite{
    public Point2 Dimension{ get; private set; }
    public Point2 Position{ get; set; }
    public PixelsMatrix Data{ get; set; }
    public Sprite(Point2 dimension,Point2 position){
        this.Dimension = dimension;
        this.Position = position;
        this.Data = new(dimension, 1);
        Data.FillWith("*");
    }
}