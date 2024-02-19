using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using Object;
using Utils;
namespace GameEngine.Engine.InvokerEngine.Commands;

public class MoveCommand : ICommand
{
    private readonly Point2 Move;
    public MoveCommand(Controller O, Point2 move, CallBack? callBack = default):base(O, callBack)
    {
        Move = move;
    }
    public override MoveResult OnExecution(IEngine engine)
    {
        if(engine.PhisicsEngine.AreThereCollisions(O.Entity,Move))return new MoveResult(false);

        O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Plus(Move));
        return new MoveResult(true);
    }

    public override void OnUndo(IEngine engine)
    {
        O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Minus(Move));
    }
}
public class MoveResult:IResult{
    public MoveResult(bool canMove)=>AddResults("canMove",canMove);
    public bool? CanMove { get { return Get<bool>("canMove"); } }
}