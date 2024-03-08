using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class DestroyMeCommand : ICommand
{
    public DestroyMeCommand(Controller o, CallBack<IResult>? callBack = null) : base(o, callBack)
    {
    }

    public override IResult OnExecution(IEngine engine)
    {
        engine.ResourceEngine.DestroyObject(O.Entity.Name);
        return new DefaultResult();
    }
    public override void OnUndo(IEngine engine)
    {
        engine.ResourceEngine.AddNewObject(O.Entity.Name,O);
    }
}
