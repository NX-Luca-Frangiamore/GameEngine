using Utils;

namespace Object;
public class Body{
    public Point2 Position{ get; set; }
    public bool IsTangible { get; set; } = true;
    public Point2 Dimension{ get;private set; }
    public Body(Point2 dimension,Point2 position){
        this.Position = position;
        this.Dimension = dimension;
    }
}