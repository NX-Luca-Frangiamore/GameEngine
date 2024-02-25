using Engine;
using Graphics.Display;
using Graphics.GraphicsEngine;
using InputEngine;
using PhysicsEngine;
using Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameEngine.Engine.InvokerEngine.Commands;
using GameEngine.Object;
using GameEngine.Object.Entity;
using System.Xml.Linq;



void StartEngine<T>(T typeLinkAssembly) where T:Type
{
    var builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddSingleton<ObjectResource>();
    builder.Services.AddSingleton<IPhisicsEngine, BasePhysicsEngine>();
    builder.Services.AddSingleton<IDisplay, ConsoleMulticolorDisplay>();
    builder.Services.AddSingleton<IGraphicsEngine, ColorGraphicsEngine>();
    builder.Services.AddSingleton<IInput, ConsoleInput>();
    builder.Services.AddSingleton<IEngine, Game>();
    var host = builder.Build();
       var engine= host.Services.GetRequiredService<IEngine>();
        engine.ResourceEngine.CollectObjects(typeLinkAssembly);
        engine.Start();
    host.Run();
}
StartEngine(typeof(Game));

public class Game :IEngine
{
    public Game(IPhisicsEngine phisicsEngine, IGraphicsEngine graphicsEngine,
                 IInput inputEngine, ObjectResource resourceEngine)
                : base(phisicsEngine, graphicsEngine, inputEngine, resourceEngine)
    {
        this.InputEngine.Delay = 100;
        DelayFrame = 100;
       
    }   
}
public class Nave : Controller
{
    private Point2 Speed = new(0, 0);
    private int nBullet = 0;
    public Nave()
    {
        Entity stillObject = Entity.New(3, new(1, 1));


        DtoCreateEntity dto = new DtoCreateEntity(3);
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.SetInfo(new(1, 2), new InfoPixel() { Color = "red" });

        SetStillObject(EntityFactory.CreateEntity(new(1, 1), dto));
    
    }
    public override void Loop()
    {
        Invoker.Execute(new GetKeyboard(this,(x)=>{
            Speed = MappingInputToVector2(x.Get<string>("Key")) ?? new(0, 0);
            if (x.Get<string>("Key") == "r")
                Invoker.Undo();
            MappingInputToRotation(x.Get<string>("Key"), this);
            if (x.Get<string>("Key") == "space")
            {
                Invoker.Execute(new CreateControllerCommand(this,"bullet"+ nBullet, new Bullet(this.Entity.AbsolutePosition.Plus(new(1,1)), MappingAngleToVector2(),Entity.Name)));
                nBullet++;
            }
        }));

        Invoker.Execute(new MoveCommand(this, Speed));

    }
    private static Point2? MappingInputToVector2(string? key) => key switch
    {
        "a" => new Point2(-1, 0),
        "d" => new Point2(1, 0),
        "w" => new Point2(0, 1),
        "s" => new Point2(0, -1),
        _ => null,
    };
    private static void MappingInputToRotation(string key, Controller c)
    {
        switch (key)
        {
            case "a": c.Invoker.Execute(new AbsoluteRotateCommand(c,270)); break;
            case "d": c.Invoker.Execute(new AbsoluteRotateCommand(c, 90)); break;
            case "w": c.Invoker.Execute(new AbsoluteRotateCommand(c, 0)); break;
            case "s": c.Invoker.Execute(new AbsoluteRotateCommand(c, 180)); break;
        }
    }
    private Point2? MappingAngleToVector2() => Entity.Sprite.Angle switch
    {
        0 => new Point2(0, -1),
        90 => new Point2(-1, 0),
        180 => new Point2(0, 1),
        270 => new Point2(1, 0),
        _ => throw new NotImplementedException(),
    };
}
internal class Bullet : Controller
{
    private Point2 Speed;
    private Point2 Init;
    private string Own;
    public Bullet(Point2 position,Point2 speed,string own)
    {
        Own=own;
        Init =position;
        var StillObject = Entity.New(1, position);
        StillObject.Sprite.Data.FillWith(new Pixel("o",new InfoPixel { Color="green"}));
        StillObject.Body.Data.SetAllTangible();
        SetStillObject(StillObject);
        Speed = new Point2(-speed.x*2,-speed.y*2);
        Entity.Body.CollideBut(Own);
    }
    public override void Loop()
    {
        Invoker.Execute(new MoveCommand(this, Speed, (x =>
        {
            if (!((MoveResult)x).CanMove)
                Entity.Body.CollideWith(Own);
        })));
        if (Init.Minus(Entity.AbsolutePosition).GetModule() > 10)
            Invoker.Execute(new DestroyMeCommand(this));
    }
}
public class Wall : Controller
{
    public Wall()
    {
        var StillObject =Entity.New(5, new(8, 1));
        StillObject.Sprite.Data.FillWith("*");
        StillObject.Body.Data.SetAllTangible();
        SetStillObject(StillObject);
    }
}
