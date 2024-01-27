using Engine;
using Graphics.Display;
using Graphics.GraphicsEngine;
using InputEngine;
using Object;
using PhysicsEngine;
using Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Invoker;

void StartEngine(Type typeLinkAssembly)
{
    var builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddSingleton<ObjectResource>();
    builder.Services.AddSingleton<IPhisicsEngine, BasePhysicsEngine>();
    builder.Services.AddSingleton<IDisplay, ConsoleMulticolorDisplay>();
    builder.Services.AddSingleton<IGraphicsEngine, ColorGraphicsEngine>();
    builder.Services.AddSingleton<IInput, ConsoleInput>();
    builder.Services.AddSingleton<Invoker.Invoker>();
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
                 IInput inputEngine, ObjectResource resourceEngine,Invoker.Invoker invoker)
                : base(phisicsEngine, graphicsEngine, inputEngine, resourceEngine,invoker)
    {
        this.InputEngine.Delay = 100;
        DelayFrame = 250;
        //Invoker.Add(new MoveCommand(new Nave(), new(1,1)));
        //Invoker.Execute(this);
    }   
}
class Nave : IObject
{
    private Point2 Speed = new(1, 0);
    public Nave()
    {
        DumbObject stillObject = new(new(1, 1), new(1, 1));
        stillObject.Skin.Data.FillWith("o");
        stillObject.Body.Parts.SetTangible(new(0, 0));
       // stillObject.Skin.Data.SetPixel(new(0, 0), new("A", new() { Color = "red" }));
        SetStillObject(stillObject);
    }
    public override void Loop()
    {
       // if(!IsInCollision)
        //    Move(Speed);
        Invoker.Add(new GetKeyboard(this,(x)=>{
            Speed = MappingInputToVector2(x.Get<string>("Key"));
        }));
        Move(Speed);

    }
    public void OnCollisionBy(string nameObject)
    {
        Move(new(-Speed.x, -Speed.y));
    }
    private Point2 MappingInputToVector2(string? key) => key switch
    {
        "left" => new Point2(-1, 0),
        "right" => new Point2(1, 0),
        "up" => new Point2(0, 1),
        "down" => new Point2(0, -1),
        _ => new(0,0),
    };
}

public class Wall : IObject
{
    public Wall()
    {
        var StillObject = new DumbObject(new(5,5), new(8,1));
        StillObject.Body.Parts.SetAllTangible();
        SetStillObject(StillObject);
    }
    public override void Loop()
    {
    }
}
