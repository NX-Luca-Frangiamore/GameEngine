using System.Reflection;
using Graphics;
using Graphics.GraphicsEngine;
using InputEngine;
using Object;
using PhysicsEngine;

namespace Engine;
public abstract partial class IEngine{
    private int _delayFrame = 500;
    public int DelayFrame { get {return _delayFrame; }set{ if (value is < MAX_TIME_FRAME and > 0) _delayFrame = value; } }
    private bool StatusLoop = true;
    private const int MAX_TIME_FRAME= 2000;
    public IPhisicsEngine PhisicsEngine;
    public IInput InputEngine;
    public ObjectResource ResourceEngine;
    public IGraphicsEngine GraphicsEngine;
    public IEngine(IPhisicsEngine phisicsEngine,IGraphicsEngine graphicsEngine,IInput inputEngine,ObjectResource resourceEngine){
        this.PhisicsEngine = phisicsEngine;
        this.GraphicsEngine = graphicsEngine;
        this.InputEngine = inputEngine;
        this.ResourceEngine = resourceEngine;
    }
    public void Start(){
        this.InputEngine.StartUpdateInput();
        this.ResourceEngine.PhGetAllObjects().ForEach(x => x.Setup(this));
        BeforeStartLoop();
        StatusLoop = true;
        Loop();
        AfterEndLoop();
    }
    public void Stop()=>this.StatusLoop = false;
    public virtual void BeforeStartLoop(){}
    public virtual void AfterEndLoop() {}
    public virtual void BeforeRefresh(){}
    public virtual void AfterRefresh(){}
    private void Loop(){
        while(StatusLoop){
            BeforeRefresh();
             ResourceEngine.PhGetAllObjects().ForEach(x=>x.Loop());
            this.GraphicsEngine.ShowFrame(ResourceEngine.GetAllObjects().Select(x=>new DtoGraphicsEngine(x.Skin,x.AbsolutePosition)).ToList());
            AfterRefresh();
            Thread.Sleep(DelayFrame);
        }
    }

}
