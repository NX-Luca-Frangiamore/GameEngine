using Engine;
using GraphicsEngine;
using InputEngine;
using Object;
using PhysicsEngine;
using Utils;
var o = new ResourceEngine();
var _try = new Game(new BasePhysicsEngine(o)
                 , new ConsoleGraphicsEngine(new Display(new(20, 20)))
                 , new ConsoleInput(),
                o);
_try.SetTimeFrame(250);
_try.StartLoop();

public class Game : Engine.Engine {
    Vector2 Speed = new Vector2(0, 0); 

    public Game(IPhisicsEngine phisicsEngine, IGraphicsEngine graphicsEngine,
                 IInput inputEngine,ResourceEngine resourceEngine) 
                : base(phisicsEngine, graphicsEngine, inputEngine,resourceEngine)
    {
    }

    public override void BeforeStartLoop()
    {
        base.BeforeStartLoop();
        Object.Object o = new(new(1, 1), new(9, 1));
        o.Skin.Data.FillWith("o");
        this.ResourceEngine.AddNewObject("prova",o);
        o = new(new(4, 4), new(0, 5));
        o.Skin.Data.FillWith("*");
        this.ResourceEngine.AddNewObject("obstacle", o); 
        this.InputEngine.Delay = 100;
        this.InputEngine.StartUpdateInput();
    }
    public override void BeforeRefresh()
    {
        this.Speed=MappingInputToVector2(this.InputEngine.state);
        this.ResourceEngine.GetObject("prova")!.SetAbsolutePosition(Speed);
    }
    private Vector2 MappingInputToVector2(string? key){
        return key switch
       {
            "left" => new Vector2(-1, 0),
            "right" => new Vector2(1, 0),
            "up" => new Vector2(0, 1),
            "down" => new Vector2(0, -1),
            _ => this.Speed,
        };
    }
}
