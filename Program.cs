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



void StartEngine(Type typeLinkAssembly)
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
StartEngine(typeof(Nave));

public class Game :IEngine
{
    public Game(IPhisicsEngine phisicsEngine, IGraphicsEngine graphicsEngine,
                 IInput inputEngine, ObjectResource resourceEngine)
                : base(phisicsEngine, graphicsEngine, inputEngine, resourceEngine)
    {
        this.InputEngine.Delay = 100;
        DelayFrame = 150;
       
    }   
}
class Nave : Controller
{
    private Point2 Speed = new(0, 0);
    public Nave()
    {
        Entity stillObject = Entity.New(3, new(1, 1));


        DtoCreateEntity dto = new DtoCreateEntity(3);
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.SetInfo(new(1, 2), new InfoPixel() { Color = "red" });
       // stillObject.Body.Data.SetTangible(new(1, 0));
       // stillObject.Body.Data.SetTangible(new(1, 1));
       // stillObject.Body.Data.SetTangible(new(1, 2));
       //
       // stillObject.Sprite.Data.SetPixel(new(1, 0), new("o", new() { Color = "green" }));
       // stillObject.Sprite.Data.SetPixel(new(1, 1), new("o", new() { Color = "green" }));
       // stillObject.Sprite.Data.SetPixel(new(1, 2), new("o", new() { Color = "red" }));

        SetStillObject(EntityFactory.CreateEntity(new(1, 1), dto)
);
    
    }
    public override void Loop()
    {
       // if(!IsInCollision)
        //    Move(Speed);
        Invoker.Execute(new GetKeyboard(this,(x)=>{
            Speed = MappingInputToVector2(x.Get<string>("Key")) ?? new(0, 0);
            if (x.Get<string>("Key") == "space")
                Invoker.Execute(new RelativeRotateCommand(this,90));
            if (x.Get<string>("Key") == "r")
                Invoker.Undo();
        }));

    Move(Speed);

    }
    private static Point2? MappingInputToVector2(string? key) => key switch
    {
        "a" => new Point2(-1, 0),
        "d" => new Point2(1, 0),
        "w" => new Point2(0, 1),
        "s" => new Point2(0, -1),
        _ => null,
    };
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
    public override void Loop()
    {
    }
}
