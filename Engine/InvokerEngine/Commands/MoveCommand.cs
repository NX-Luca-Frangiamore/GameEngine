using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
using PhysicsEngine;
using Utils;
namespace GameEngine.Engine.InvokerEngine.Commands;

public class MoveCommand : ICommand
{
    private readonly Point2 Move;
    public MoveCommand(Controller O, Point2 move, CallBack<MoveResult>? callBack = default):base(O, 
		    callBack is null?default:(x)=>callBack((MoveResult)x))
    {
        Move = move;
    }
    public override MoveResult OnExecution(IEngine engine)
    {
        var (versore,module)= Move.GetVersore();
        for (var i = 0; i < module; i++)
        {
           if(engine.PhisicsEngine.AreThereCollisions(O.Entity, versore) is CollisionInfo collisionInfo) 
                if(collisionInfo.CrushedWith?.Name is not null)
                     return new MoveResult(false); ;
           O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Plus(versore));
        }
        return new MoveResult(true);
    }

    public override void OnUndo(IEngine engine)
    {
        O.Entity.SetAbsolutePosition(O.Entity.AbsolutePosition.Minus(Move));
    }
}
public class MoveResult(bool canMove):IResult{
	public readonly bool CanMove=canMove;
}
