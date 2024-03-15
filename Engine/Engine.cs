using Graphics;
using Graphics.GraphicsEngine;
using InputEngine;
using PhysicsEngine;
using GameEngine.Engine.InvokerEngine;
using Graphics.Display;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace Engine;

public class IEngine
{
    private int _delayFrame = 500;
    private bool StatusLoop = true;
    private const int MAX_TIME_FRAME = 2000;
    public IPhisicsEngine PhisicsEngine { get; private set; }
    public IInput InputEngine { get; private set; }
    public ObjectResource ResourceEngine { get; private set; }
    public IGraphicsEngine GraphicsEngine { get; private set; }

    public IEngine(IPhisicsEngine phisicsEngine, IGraphicsEngine graphicsEngine, IInput inputEngine, ObjectResource resourceEngine)
    {
        this.PhisicsEngine = phisicsEngine;
        this.GraphicsEngine = graphicsEngine;
        this.InputEngine = inputEngine;
        this.ResourceEngine = resourceEngine;
    }

    public void Start()
    {
        this.InputEngine.StartUpdateInput();
        this.ResourceEngine.GetAllController().ForEach(x => x.SetUp(new Invoker(this)));
        BeforeStartLoop();
        StatusLoop = true;
        Loop();
        AfterEndLoop();
    }

    public void Stop() => this.StatusLoop = false;
    public Action BeforeStartLoop = () => { };
    public Action BeforeRefresh = () => { };
    public Action AfterEndLoop = () => { };
    public Action AfterRefresh = () => { };

    private void Loop()
    {
        while (StatusLoop)
        {
            BeforeRefresh();
            ResourceEngine.GetAllController().ForEach(x => x.Loop());
            var dtos = ResourceEngine.GetAllController().Select(x => new DtoGraphicsEngine(x.Entity.Sprite, x.Entity.AbsolutePosition)).ToList();
            GraphicsEngine.ShowFrame(dtos);
            AfterRefresh();
            Thread.Sleep(_delayFrame);
        }
    }
    public static IEngine StartEngine<T>()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<ObjectResource>();
        builder.Services.AddSingleton<IPhisicsEngine, BasePhysicsEngine>();
        builder.Services.AddSingleton<IDisplay, ConsoleMulticolorDisplay>();
        builder.Services.AddSingleton<IGraphicsEngine, ColorGraphicsEngine>();
        builder.Services.AddSingleton<IInput, ConsoleInput>();
        builder.Services.AddSingleton<IEngine>();
        var host = builder.Build();
        var engine = host.Services.GetRequiredService<IEngine>();
        host.RunAsync();
        engine.ResourceEngine.CollectObjects(typeof(T));
        return engine;
    }
    public IEngine SetDelayFrame(int value)
    {
        if (value is < MAX_TIME_FRAME and > 0)
            this._delayFrame = value;
        return this;
    }
    public IEngine SetDelayInput(int value)
    {
        this.InputEngine.Delay = value;
        return this;
    }
}
public static class ExtensionsEngine
{
}
