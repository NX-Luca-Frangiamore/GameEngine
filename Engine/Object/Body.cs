using Utils;

namespace Object;
public class Body{
    public bool IsTangible { get; set; } = true;
    public CollisionMatrix Part{get;private set;}
    public Point2 Position{get;private set;}
    public Body(CollisionMatrix part,Point2 position){
        Part=part;
        Position=position;
    }
    public void RotateBodyOf90()=>Part=Part.GetCollisionMatrixRotatedOf90();
}