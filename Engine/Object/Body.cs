using Utils;

namespace GameEngine.Object;
public class Body{
    public bool IsTangible { get; set; } = true;
    public Point2 Position { get; set; }
    public int Angle {  get; private set; }
    public CollisionMatrix Data { get; set; }
    public Body(Point2 dimension, Point2 position)
    {
        Position=position;
        Data=new CollisionMatrix(dimension);
    }

    public Body Clone()
    {
        var cloned = new Body(Data.Dimension, Position);
        cloned.Data = Data.Clone();
        return cloned;
    }

    public void AbsoluteRotate(int angle)
    {
        int diffAngle = angle - Angle;
        if (diffAngle > 0)
        {
            Angle = diffAngle;
            Data.RelativeRotate(diffAngle);
        }
        else if (diffAngle < 0)
        {
            Angle = diffAngle + 360;
            Data.RelativeRotate(diffAngle + 360);
        }
    }
}