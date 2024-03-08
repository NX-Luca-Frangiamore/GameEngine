using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
using ICommand = GameEngine.Engine.InvokerEngine.Abstracts.ICommand;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class GetControllerCommand(Controller o, string Name, CallBack<GetControllerResult>? callBack = null) 
	: ICommand(o, callBack is null?default:x=>callBack((GetControllerResult)x))
{
    public override IResult OnExecution(IEngine engine)
    {
        var r=engine.ResourceEngine.GetObject(Name);
        return new GetControllerResult(r);
    }
}
public class GetControllerResult(Controller?c=default) : IResult
{
	public readonly Controller? controller=c;
}

