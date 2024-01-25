using Engine;
using Object;
using PhysicsEngine;
using Utils;
namespace Invoker;
public class Invoker
{
  //  private List<ICommand<IResult>> Commands = new List<ICommand<IResult>>();
    private List<ICommand>Commands=new List<ICommand>();
    public void Add(ICommand command)
    {
        Commands.Add(command);
    }

    public void Execute(IEngine engine)
    {
        foreach (var c in Commands)
            c.Execute(engine);
        Commands.Clear();
    }
}
public class MoveCommand: ICommand
{
    private Point2 Move;
    public MoveCommand(IObject o,Point2 move,CallBack callBack):base(o,callBack){
      Move=move;
    }
    public override MoveResult OnExecution(IEngine engine)
    {
        if(engine.PhisicsEngine.AreThereCollisions(o,Move))return new MoveResult{CanMove=false};

        o.DumbObject.SetAbsolutePosition(o.DumbObject.AbsolutePosition.Plus(Move));
        return new MoveResult{CanMove=false};
    }
}
public class MoveResult:IResult{
    public new bool CanMove;
    public new string? BlockedFrom;
    public new string? Description;
}