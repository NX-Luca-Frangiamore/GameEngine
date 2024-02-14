using Engine;
using Object;


namespace GameEngine.Engine.InvokerEngine.Abstracts;

public delegate void CallBack(IResult result);
public abstract class ICommand{
    public Controller O{get;private set;}
    public string FromWho{get;init;}
    private readonly CallBack CallBack;
    public ICommand(Controller o,CallBack? callBack=default){
        this.O=o;
        FromWho=o.Name;
        CallBack = callBack??((x)=>{});
    }
    public void Execute(IEngine engine){
        CallBack(OnExecution(engine));
    }
    public void Undo(IEngine engine){
        CallBack(OnUndo(engine));
    }
    public abstract IResult OnExecution(IEngine engine);
    public abstract IResult OnUndo(IEngine engine);
}