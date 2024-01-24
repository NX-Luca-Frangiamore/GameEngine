using Utils;

public class CollisionMatrix : Matrix<bool>
{
    public CollisionMatrix(Point2 dimension) : base(dimension,false){}
    public void SetTangible(Point2 v) => this.SetElement(v, true);
    public CollisionMatrix GetCollisionMatrixRotatedOf90(){
        var tMatrix = new CollisionMatrix(new(Dimension.y, Dimension.x));
        tMatrix.Elements = GetMatrixWithRotationOf90();
        return tMatrix;
    }
    public bool IsThereCollision(Point2 position)=>GetElement(position);
}