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
    public void RelativeRotate(int angle)
    {
        Angle+=angle;
        if (Angle >= 360) Angle -= 360;
        Data.RelativeRotate(angle);
    }
    public void AbsoluteRotate(int angle)
    {
        int diffAngle = angle-Angle;
        Angle = angle;
        if (diffAngle > 0)
            Data.RelativeRotate(diffAngle);
        else if(diffAngle < 0)
            Data.RelativeRotate(diffAngle + 360);
    }
    public Sprite Clone()
    {
        var cloned = new Sprite(Data.Dimension, Position);
        cloned.Data = Data.Clone();
        return cloned;
    }

}