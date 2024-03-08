using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class CreateControllerCommand(Controller o,string name, Controller newC, CallBack<IResult>? callBack = null) : ICommand(o, callBack)
{
    public override IResult OnExecution(IEngine engine)
    {
        newC.Entity.Name = name;
        newC.SetUp(O.Invoker);
        engine.ResourceEngine.AddNewObject(name, newC);
        return new DefaultResult();
    }
    public override void OnUndo(IEngine engine)
    {
        engine.ResourceEngine.DestroyObject(name);
    }
}
