using Screen;
using Utils;

var _try=new Game(new Display(new(20, 20), 1),new ConsoleInput());
_try.SetTimeFrame(250);
_try.StartLoop();

public class Game : GameIstanceBase {
    Vector2 Speed = new Vector2(0, 0); 
    readonly IInput InputManager;
    public Game(Display display,IInput inputManager):base(display)
    {
        this.InputManager = inputManager;
    }

    public override void BeforeStartLoop()
    {
        base.BeforeStartLoop();
        BaseObject o = new(new(2, 2), new(0, 1), 1);
        o.Sprite.FillWith("o");
        resourcesManager.AddNewObject("prova",o);
        o = new(new(4, 4), new(0, 5), 1);
        o.Sprite.FillWith("*");
        resourcesManager.AddNewObject("obstacle", o); 
        this.Display.SetFrame(this.Display.NewEmptyFrame());
        this.InputManager.Delay = 100;
        this.InputManager.StartUpdateInput();
    }
    public override void BeforeRefresh()
    {
        this.Speed=MappingInputToVector2(this.InputManager.state);
        this.resourcesManager.MoveObjectWithV("prova", Speed);
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
