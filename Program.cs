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
        DelayFrame = 300;   
    }
}
class Nave : IObject
{
    private Point2 Speed = new(0, 0);
    public Nave()
    {
        DumbObject stillObject = new(new(1, 2), new(6, 1));
        stillObject.Skin.Data.FillWith("o");
        stillObject.Skin.Data.SetPixel(new(0, 0), new("A", new() { Color = "red" }));
        SetStillObject(stillObject);
        DumbObject.RotateOf90();
        DumbObject.RotateOf90();
        DumbObject.RotateOf90();

    }
    public override void Loop()
    {
        Speed = MappingInputToVector2(this.Engine.InputEngine.keyPressed);
        this.Move(Speed);
    }

    private Point2 MappingInputToVector2(string? key) => key switch
    {
        "left" => new Point2(-1, 0),
        "right" => new Point2(1, 0),
        "up" => new Point2(0, 1),
        "down" => new Point2(0, -1),
        _ => this.Speed,
    };
}
public class Wall : IObject
{
    public Wall()
    {
        var StillObject = new DumbObject(new(5,5), new(8,1));
        SetStillObject(StillObject);
    }
    public override void Loop()
    {
    }
}
