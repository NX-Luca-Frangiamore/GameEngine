using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;

namespace GameEngine.Engine.InvokerEngine.Commands;
public class AbsoluteRotateCommand(Controller o, int angle, CallBack? callBack = default) : ICommand(o,callBack)
{
    private readonly int Angle = angle;

    public override RotateResult OnExecution(IEngine engine) {
        O.Entity.AbsoluteRotate(Angle);
        var r = engine.PhisicsEngine.AreThereCollisions(O.Entity, new(0, 0));
        if (r)O.Entity.AbsoluteRotate(360-Angle);
        return new RotateResult(!r);
    }
    public override void OnUndo(IEngine engine)
    {
        O.Entity.RelativeRotate(O.Entity.Body.Angle-angle);
    }
}

