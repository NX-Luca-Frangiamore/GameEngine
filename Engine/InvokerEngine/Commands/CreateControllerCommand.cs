using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class CreateControllerCommand(Controller o,string name, Controller newC, CallBack? callBack = null) : ICommand(o, callBack)
{
    public override IResult OnExecution(IEngine engine)
    {
        newC.Entity.Name = name;
        newC.SetUp(O.Invoker);
        engine.ResourceEngine.AddNewObject(name, newC);
        return new DefaultResult();
    }
}