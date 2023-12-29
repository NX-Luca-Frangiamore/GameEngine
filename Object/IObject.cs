using Utils;

public abstract class IObject{
    public PixelsMatrix Sprite{ get; protected set; }

    public Vector2 Position{ get; protected set; }

    public IObject(Vector2 dimension, Vector2 position,int nCharactersPixel) {
        this.Position = position;
        this.Sprite = new(dimension, nCharactersPixel);        
    }
}

public class BaseObject : IObject
{
    public bool CanCompenetrate=false;
    public BaseObject(Vector2 dimension, Vector2 position,int nCharactersPixel):base(dimension,position,nCharactersPixel) {
    }
    public void Move(Vector2 p){
        Position = Position.Plus(p);
    }
}