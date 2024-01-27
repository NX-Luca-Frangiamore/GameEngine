using Utils;

namespace Object;
public class Body{
    public bool IsTangible { get; set; } = true;
    public CollisionMatrix Parts{get;private set;}
    public Point2 Position{get;private set;}
    public Body(CollisionMatrix part,Point2 position){
        Parts=part;
        Position=position;
    }
    public void RotateBodyOf90()=>Parts=Parts.GetCollisionMatrixRotatedOf90();
}