using GraphicsEngine;
using InputEngine;
using PhysicsEngine;

namespace Engine;
public abstract partial class Engine{
    private int TimeFrame = 500;
    private bool StatusLoop = true;
    private const int MAX_TIME_FRAME= 2000;
    private IPhisicsEngine PhisicsEngine;
    protected IInput InputEngine;
    protected ResourceEngine ResourceEngine;
    private IGraphicsEngine GraphicsEngine;
    public Engine(IPhisicsEngine phisicsEngine,IGraphicsEngine graphicsEngine,IInput inputEngine,ResourceEngine resourceEngine){
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

    public virtual void BeforeStartLoop() {}
    public virtual void AfterEndLoop() {}
    public virtual void BeforeRefresh(){}
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
            this.GraphicsEngine.ShowFrame(ResourceEngine.GetAllObjects());
            AfterRefresh();
            Thread.Sleep(TimeFrame);
        }
    }

    public void StopLoop()=>this.StatusLoop = false;
}
