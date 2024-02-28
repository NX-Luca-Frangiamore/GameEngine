using Utils;

namespace GameEngine.Object;
public class Body{
    public bool IsTangible { get; set; } = true;
    public bool IsPermeable { get; set; } = false;
    public Point2 Position { get; set; }
    public int Angle {  get; private set; }
    public CollisionMatrix Data { get; set; }
    public List<string> Expect=[];
    public Body(Point2 dimension, Point2 position)
    {
        Position=position;
        Data=new CollisionMatrix(dimension);
    }
    public void CollideBut(string name)=>Expect.Add(name);
    public void CollideWith(string name) => Expect.Remove(name);
    public Body Clone()
    {
        var cloned = new Body(Data.Dimension, Position);
        cloned.Data = Data.Clone();
        return cloned;
    }
    public void RelativeRotate(int angle)
    {
        Angle += angle;
        if (Angle >= 360) Angle -= 360;
        Data.RelativeRotate(angle);
    }

    public void AbsoluteRotate(int angle)
    {
        int diffAngle = angle - Angle;
        Angle = angle;
        if (diffAngle > 0)
            Data.RelativeRotate(diffAngle);
        else if (diffAngle < 0)
            Data.RelativeRotate(diffAngle + 360);
    }
}