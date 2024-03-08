using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class RelativeRotateCommand(Controller o, int angle, CallBack<RotateResult>? callBack = default) 
	: ICommand(o,callBack is null?default:(x)=>callBack((RotateResult)x))
{
    private readonly int Angle = angle;

    public override RotateResult OnExecution(IEngine engine) {
        O.Entity.RelativeRotate(Angle);
        var r = engine.PhisicsEngine.AreThereCollisions(O.Entity, new(0, 0));
        if (r.CrushedWith is null)O.Entity.RelativeRotate(360-Angle);
        return new RotateResult(true);
    }
    public override void OnUndo(IEngine engine)
    {
        O.Entity.RelativeRotate(360-Angle);
    }
}
public class RotateResult(bool canRotate) : IResult
{
    public readonly bool CanRotate=canRotate;
}

