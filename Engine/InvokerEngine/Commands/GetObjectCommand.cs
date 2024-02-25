using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = GameEngine.Engine.InvokerEngine.Abstracts.ICommand;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class GetControllerCommand(Controller o, string Name, CallBack? callBack = null) : ICommand(o, callBack)
{
    public override IResult OnExecution(IEngine engine)
    {
        var r=engine.ResourceEngine.GetObject(Name);
        return new GetControllerResult(r);
    }
}
public class GetControllerResult : IResult
{
    public GetControllerResult(Controller? c) => AddResults("Object", c);
}

