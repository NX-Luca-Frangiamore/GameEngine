using Utils;

namespace Object;
public class Body{
    public Point2 Position{ get; private set; }
    public Point2 Dimension{ get; private set; }
    public Body(Point2 dimension,Point2 position){
        this.Position = position;
        this.Dimension = dimension;
    }
    public bool SetPositionPosition(Point2 position){
        this.Position = position;
        return true;
    }
}