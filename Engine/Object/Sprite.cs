using Graphics;
using Utils;
namespace GameEngine.Object;
public class Sprite
{
    public bool IsVisible=true;
    
    public Point2 Position;
    public int Angle {  get; private set; }
    public PixelsMatrix Data { get; private set; }
    public Sprite(Point2 dimension, Point2 position)
    {
        Data=new PixelsMatrix(dimension,1);
        this.Position = position;
    }
    public void AbsoluteRotate(int angle)
    {
        int diffAngle = angle-Angle;
        if (diffAngle > 0) {
            Angle = diffAngle;
            Data.RelativeRotate(diffAngle);
        }
        else if(diffAngle < 0) {
            Angle = diffAngle+360;
            Data.RelativeRotate(diffAngle + 360);
        }
    }
    public Sprite Clone()
    {
        var cloned = new Sprite(Data.Dimension, Position);
        cloned.Data = Data.Clone();
        return cloned;
    }

}