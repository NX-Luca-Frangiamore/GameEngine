using Engine;
using Graphics.Display;
using Graphics.GraphicsEngine;
using InputEngine;
using Object;
using PhysicsEngine;
using Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameEngine.Engine.InvokerEngine;
using GameEngine.Engine.InvokerEngine.Commands;



void StartEngine(Type typeLinkAssembly)
{
    var builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddSingleton<ObjectResource>();
    builder.Services.AddSingleton<IPhisicsEngine, BasePhysicsEngine>();
    builder.Services.AddSingleton<IDisplay, ConsoleMulticolorDisplay>();
    builder.Services.AddSingleton<IGraphicsEngine, ColorGraphicsEngine>();
    builder.Services.AddSingleton<IInput, ConsoleInput>();
    builder.Services.AddSingleton<IInvoker,Invoker>();
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
                 IInput inputEngine, ObjectResource resourceEngine,IInvoker invoker)
                : base(phisicsEngine, graphicsEngine, inputEngine, resourceEngine,invoker)
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
        Object.Entity stillObject = new(new(3, 3), new(1, 1));
        //stillObject.Skin.FillWith("o");
        stillObject.Body.SetTangible(new(1, 0));
        stillObject.Body.SetTangible(new(1, 1));
        stillObject.Body.SetTangible(new(1, 2));

        stillObject.Skin.SetPixel(new(1, 0), new("o", new() { Color = "green" }));
        stillObject.Skin.SetPixel(new(1, 1), new("o", new() { Color = "green" }));
        stillObject.Skin.SetPixel(new(1, 2), new("o", new() { Color = "red" }));
        SetStillObject(stillObject);



    }
    public override void Loop()
    {
       // if(!IsInCollision)
        //    Move(Speed);
        Invoker.AddCommand(new GetKeyboard(this,(x)=>{
            Speed = MappingInputToVector2(x.Get<string>("Key"))??new(0,0);
            if (x.Get<string>("Key") == "space") AbsoluteRotate(90);
        }));
        Move(Speed);

    }
    public void OnCollisionBy(string nameObject)
    {
        Move(new(-Speed.x, -Speed.y));
    }
    private Point2? MappingInputToVector2(string? key) => key switch
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
        var StillObject = new Entity(new(5,5), new(8,1));
        StillObject.Skin.FillWith("*");
        StillObject.Body.SetAllTangible();
        SetStillObject(StillObject);
    }
    public override void Loop()
    {
    }
}
