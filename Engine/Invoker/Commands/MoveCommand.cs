using Engine;
using Object;
using PhysicsEngine;
using Utils;
namespace Invoker;
public class Invoker{
    private List<ICommand> Commands=new List<ICommand>();
    public void Add(ICommand command){
        Commands.Add(command);
    }
    public void Execute(IEngine engine){
        foreach(var c in Commands)
            c.Execute(engine);
        Commands.Clear();
    }

}
public class MoveCommand: ICommand
{
    private Point2 Move;
    public MoveCommand(IObject o,Point2 move):base(o){
      Move=move;
    }
    public override IResult Execute(IEngine engine)
    {
        if(engine.PhisicsEngine.AreThereCollisions(o,Move))return new EmptyResult();
        o.DumbObject.SetAbsolutePosition(o.DumbObject.AbsolutePosition.Plus(Move));
        return new EmptyResult();
    }
}