using Engine;
using Screen;

public abstract class GameIstanceBase{
    private int TimeFrame = 100;
    private const int MAX_TIME_FRAME= 2000;
    public Display Display;
    public ResourcesManager resourcesManager = new();
    public GameIstanceBase(Display display){
        this.Display = display;
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
        Loop();
        AfterEndLoop();
    }
    private void Loop(){
        while(true){
            BeforeRefresh();
            this.Display.SetFrame(this.resourcesManager.GetComposedPixels(this.Display.NewEmptyFrame()!));
            this.Display.ShowFrame();
            AfterRefresh();
            Thread.Sleep(TimeFrame);
        }
    } 
}
