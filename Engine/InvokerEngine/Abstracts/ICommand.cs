using Engine;
using GameEngine.Object;


namespace GameEngine.Engine.InvokerEngine.Abstracts;

public delegate void CallBack<IT>(IT result);
public abstract class ICommand(Controller o, CallBack<IResult>? callBack = default)
{
    public Controller O { get; private set; } = o;
    public string FromWho { get; init; } = o.Entity.Name;
    private readonly CallBack<IResult> CallBack = callBack ?? ((x) => { });

    public void Execute(IEngine engine)
    {
        CallBack(OnExecution(engine));
    }
    public void Undo(IEngine engine)
    {
        OnUndo(engine);
    }
    public abstract IResult OnExecution(IEngine engine);
    public virtual void OnUndo(IEngine engine) { }
}
