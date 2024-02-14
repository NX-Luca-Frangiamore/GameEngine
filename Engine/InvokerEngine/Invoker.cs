using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;

namespace GameEngine.Engine.InvokerEngine;
public class Invoker : IInvoker
{
    private readonly List<ICommand>BufferCommands=[];
    private readonly Stack<ICommand>HistoryCommands=[];

    public void AddCommand(ICommand command) => BufferCommands.Add(command);

    public void Execute(IEngine engine)
    {
        foreach (var c in BufferCommands){
            c.Execute(engine);
            HistoryCommands.Push(c);
        }
        BufferCommands.Clear();
    }

    public void Undo(IEngine engine)
    {
         foreach (var c in HistoryCommands){
            c.Undo(engine);
        }
    }
}
