using Graphics;
using Utils;

public class Sprite{
    public Point2 Dimension{ get; private set; }
    public Point2 Position{ get; private set; }
    public PixelsMatrix Data{ get; private set; }
    public Sprite(Point2 dimension,Point2 position){
        this.Dimension = dimension;
        this.Position = position;
        this.Data = new(dimension, 1);
        Data.FillWith("*");
    }
    public void SetSpritePosition(PixelsMatrix data){
        this.Data = data;
    }
}