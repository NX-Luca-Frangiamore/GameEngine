using Graphics;
using Graphics.GraphicsEngine;
using InputEngine;
using PhysicsEngine;

namespace Engine;
public abstract partial class Engine{
    private int TimeFrame = 500;
    private bool StatusLoop = true;
    private const int MAX_TIME_FRAME= 2000;
    public IPhisicsEngine PhisicsEngine;
    public IInput InputEngine;
    public ObjectResource ResourceEngine;
    public IGraphicsEngine GraphicsEngine;
    public Engine(IPhisicsEngine phisicsEngine,IGraphicsEngine graphicsEngine,IInput inputEngine,ObjectResource resourceEngine){
        this.PhisicsEngine = phisicsEngine;
        this.GraphicsEngine = graphicsEngine;
        this.InputEngine = inputEngine;
        this.ResourceEngine = resourceEngine;
    }

    public void SetTimeFrame(int time){
        if (time > MAX_TIME_FRAME) return;
        if (time <= 0) return;
        TimeFrame = time;
    }

    public virtual void BeforeStartLoop()
    {
        this.InputEngine.StartUpdateInput();
        this.ResourceEngine.PhGetAllObjects().ForEach(x => x.Setup(this));
    }
    public virtual void AfterEndLoop() {}
    public virtual void BeforeRefresh(){
        ResourceEngine.PhGetAllObjects().ForEach(x=>x.Loop());
    }
    public virtual void AfterRefresh(){}
    public void StartLoop(){
        BeforeStartLoop();
        StatusLoop = true;
        Loop();
        AfterEndLoop();
    }

    private void Loop(){
        while(StatusLoop){
            BeforeRefresh();
            this.GraphicsEngine.ShowFrame(ResourceEngine.GetAllObjects().Select(x=>new DtoGraphicsEngine(x.Skin,x.AbsolutePosition)).ToList());
            AfterRefresh();
            Thread.Sleep(TimeFrame);
        }
    }

    public void StopLoop()=>this.StatusLoop = false;
}
