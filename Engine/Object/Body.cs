using Utils;

namespace Object;
public class Body{
    public Vector2 Position{ get; private set; }
    public Body(Vector2 position){
        this.Position = position;
    }
    public bool SetPositionPosition(Vector2 position){
        this.Position = position;
        return true;
    }
}