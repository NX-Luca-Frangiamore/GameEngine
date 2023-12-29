using Graphics;
using Utils;
namespace Object;
public class Object{
    public Sprite Skin{ get; protected set; }
    public Body Body{ get; protected set; }
    public bool IsTangible{ get; protected set; }
    public Vector2 AbsolutePosition{ get; private set; }
    public Object(Vector2 dimension, Vector2 position) {
        this.Skin = new(dimension,new(0,0) );
        this.Body = new(new(0,0));
        this.AbsolutePosition = position;        
    }
    public bool SetAbsolutePosition(Vector2 v){
        this.AbsolutePosition=this.AbsolutePosition.Plus(v);
        return true;
    }
}