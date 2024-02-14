using Utils;

public abstract class CollisionMatrix : Matrix<bool>
{
    public CollisionMatrix(Point2 dimension) : base(dimension,false){}
    public void SetTangible(Point2 v) => this.SetElement(v, true);
    public void SetAllTangible() => AddInAllElement(true);
    public bool IsThereCollision(Point2 position)=>GetElement(position);
    public abstract void AbsoluteRotate(int angle);

}