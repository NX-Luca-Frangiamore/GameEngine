using Engine;
using GraphicsEngine;
using InputEngine;
using Object;
using PhysicsEngine;
using Utils;
var o = new ObjectResource();
var _try = new Game(new BasePhysicsEngine(o)
                 , new ConsoleGraphicsEngine(new Display(new(20, 20)))
                 , new ConsoleInput(),
                o);
_try.SetTimeFrame(100);
_try.ResourceEngine.AddNewObject("nave", new Nave());
_try.ResourceEngine.AddNewObject("muro1", new Wall(new(3, 3), new(0, 0)));

_try.ResourceEngine.AddNewObject("muro2", new Wall(new(3, 3), new(10, 4)));
_try.StartLoop();

public class Game : Engine.Engine {//ha un utilità?
    public Game(IPhisicsEngine phisicsEngine, IGraphicsEngine graphicsEngine,
                 IInput inputEngine,ObjectResource resourceEngine) 
                : base(phisicsEngine, graphicsEngine, inputEngine,resourceEngine)
    {
    }
}
class Nave : PhysicsObject
{
    private Point2 Speed=new(0,0);
    public Nave(){
        StillObject stillObject = new(new(1, 2), new(10, 10));
        stillObject.Skin.Data.FillWith("*");
        SetStillObject(stillObject);
    }
    public override void Loop()
    {
        Speed = MappingInputToVector2(this.Engine.InputEngine.state);
        this.Move(Speed);
    }
    private Point2 MappingInputToVector2(string? key)=> key switch
    {
            "left" => new Point2(-1, 0),
            "right" => new Point2(1, 0),
            "up" => new Point2(0, 1),
            "down" => new Point2(0, -1),
            _ => this.Speed,
    };
}
public class Wall : PhysicsObject
{
    public Wall(Point2 size,Point2 p){
        var StillObject = new StillObject(size, p);
        SetStillObject(StillObject);
    }
    public override void Loop()
    {
    }
}
