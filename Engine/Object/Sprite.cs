using Graphics;
using Utils;

public class Sprite{
    public Vector2 Dimension{ get; private set; }
    public Vector2 Position{ get; private set; }
    public PixelsMatrix Data{ get; private set; }
    public Sprite(Vector2 dimension,Vector2 position){
        this.Dimension = dimension;
        this.Position = position;
        this.Data = new(dimension, 1);
    }
    public void SetSpritePosition(PixelsMatrix data){
        this.Data = data;
    }
}