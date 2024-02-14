using Graphics;
using Utils;

public class Sprite(Point2 dimension, Point2 position) : PixelsMatrix(dimension,1)
{
    public bool IsVisible=true;
    
    public Point2 Position = position;
    public int Angle {  get; private set; }
    public void AbsoluteRotate(int angle)
    {
        int diffAngle = angle-Angle;
        if (diffAngle > 0) {
            Angle = diffAngle;
            Rotate(diffAngle);
        }
        else if(diffAngle < 0) {
            Angle = diffAngle+360;
            Rotate(diffAngle + 360);
        }
    }

}