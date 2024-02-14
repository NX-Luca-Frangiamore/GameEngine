using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using Object;
using Utils;
namespace GameEngine.Engine.InvokerEngine.Commands;

public class MoveCommand(Controller O, Point2 Move, CallBack? callBack = default) : ICommand(O,callBack)
{
    public override MoveResult OnExecution(IEngine engine)
    {
        if(engine.PhisicsEngine.AreThereCollisions(O,Move))return new MoveResult(false);

        O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Plus(Move));
        return new MoveResult(true);
    }

    public override IResult OnUndo(IEngine engine)
    {
        O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Minus(Move));
        return new MoveResult(true);
    }
}
public class MoveResult:IResult{
    public MoveResult(bool canMove)=>AddResults("canMove",canMove);
}