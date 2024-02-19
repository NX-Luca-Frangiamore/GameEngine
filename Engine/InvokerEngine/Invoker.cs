using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;

namespace GameEngine.Engine.InvokerEngine;
public class Invoker(IEngine engine): IInvoker
{
    private readonly Stack<ICommand>HistoryCommands=[];

    public void Execute(ICommand command)
    {
        command.Execute(engine);
        HistoryCommands.Push(command);
    }

    public void Undo()
    {
        foreach (var c in HistoryCommands){
            c.Undo(engine);
        }
        HistoryCommands.Clear();

    }
}
