using Utils;

class CollisionMatrix : Matrix<bool>
{
    protected CollisionMatrix(Point2 dimension) : base(dimension,false)
    {
    }
    public void SetTangible(Point2 v) => this.SetElement(v, true);
    public void SetTINTANGIBLE(Point2 v) => this.SetElement(v, false);
}