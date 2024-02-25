using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class DestroyMeCommand : ICommand
{
    public DestroyMeCommand(Controller o, CallBack? callBack = null) : base(o, callBack)
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
