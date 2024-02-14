using Utils;

namespace Object;
public class Body(Point2 dimension, Point2 position) : CollisionMatrix(dimension){
    public bool IsTangible { get; set; } = true;
    public Point2 Position { get; set; } = position;
    public int Angle {  get; private set; }
    public override void AbsoluteRotate(int angle)
    {
        int diffAngle = angle - Angle;
        if (diffAngle > 0)
        {
            Angle = diffAngle;
            Rotate(diffAngle);
        }
        else if (diffAngle < 0)
        {
            Angle = diffAngle + 360;
            Rotate(diffAngle + 360);
        }
    }
}