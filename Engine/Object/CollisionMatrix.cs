using Utils;

public class CollisionMatrix : Matrix<bool>
{
    public CollisionMatrix(Point2 dimension) : base(dimension,false){}
    public CollisionMatrix(Point2 dimension,Dictionary<Point2,bool> elemets) : base(dimension, false,elemets) { }
    public void SetTangible(Point2 v) => this.SetElement(v, true);
    public void SetAllTangible() => AddInAllElement(true);
    public CollisionMatrix GetCollisionMatrixRotatedOf90()=>new(new(Dimension.y, Dimension.x), GetMatrixWithRotationOf90());
    public bool IsThereCollision(Point2 position)=>GetElement(position);
}