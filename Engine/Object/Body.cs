using Utils;

namespace Object;
public class Body{
    public bool IsTangible { get; set; } = true;
    public CollisionMatrix Data{get;private set;}
    public Point2 Position{get;private set;}
    public Body(Point2 dimension,Point2 position){
        Position=position;
        Data = new CollisionMatrix(dimension);
    }
    public void RotateBodyOf90()=>Data=Data.GetCollisionMatrixRotatedOf90();
}