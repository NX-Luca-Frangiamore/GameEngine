using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class RelativeRotateCommand(Controller o, int angle, CallBack? callBack = default) : ICommand(o,callBack)
{
    private readonly int Angle = angle;

    public override RotateResult OnExecution(IEngine engine) {
        O.RelativeRotate(Angle);
        var r = engine.PhisicsEngine.AreThereCollisions(O.Entity, new(0, 0));
        if (r)O.RelativeRotate(360-Angle);
        return new RotateResult(!r);
    }
    public override void OnUndo(IEngine engine)
    {
        O.RelativeRotate(360-Angle);
    }
}
public class RotateResult : IResult
{
    public RotateResult(bool canRotate) => AddResults("canRotate", canRotate);
}

