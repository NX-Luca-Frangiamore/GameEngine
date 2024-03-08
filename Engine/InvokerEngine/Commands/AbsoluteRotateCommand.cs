using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class AbsoluteRotateCommand(Controller o, int Angle, CallBack<RotateResult>? callBack = default) :
	     ICommand(o,callBack is null?default:(x)=>callBack((RotateResult)x)){

    public override RotateResult OnExecution(IEngine engine) {
        O.Entity.AbsoluteRotate(Angle);
        var r = engine.PhisicsEngine.AreThereCollisions(O.Entity, new(0, 0));
        if (r is null)O.Entity.AbsoluteRotate(360-Angle);
        return new RotateResult(r is null);
    }
    public override void OnUndo(IEngine engine)
    {
        O.Entity.RelativeRotate(O.Entity.Body.Angle-Angle);
    }
}

