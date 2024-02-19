using Engine;
using GameEngine.Object;


namespace GameEngine.Engine.InvokerEngine.Abstracts;

public delegate void CallBack(IResult result);
public abstract class ICommand(Controller o, CallBack? callBack = default)
{
    public Controller O { get; private set; } = o;
    public string FromWho { get; init; } = o.Name;
    private readonly CallBack CallBack = callBack ?? ((x) => { });

    public void Execute(IEngine engine){
        CallBack(OnExecution(engine));
    }
    public void Undo(IEngine engine){
        OnUndo(engine);
    }
    public abstract IResult OnExecution(IEngine engine);
    public abstract void OnUndo(IEngine engine);
}