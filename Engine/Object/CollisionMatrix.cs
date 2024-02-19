using Graphics;
using Utils;

namespace GameEngine.Object;
public class CollisionMatrix : Matrix<bool>
{
    public CollisionMatrix(Point2 dimension) : base(dimension, false) { }
    public CollisionMatrix(Point2 dimension, Dictionary<Point2, bool> elemets) : base(dimension, false, elemets) { }
    public void SetTangible(Point2 v) => SetElement(v, true);
    public void SetAllTangible() => AddInAllElement(true);
    public bool IsThereCollision(Point2 position) => GetElement(position);
    public CollisionMatrix Clone()
    {
        var t = new CollisionMatrix(Dimension);
        t.SetElements(Elements); return t;
    }

}
