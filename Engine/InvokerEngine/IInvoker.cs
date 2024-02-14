using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;

namespace GameEngine.Engine.InvokerEngine;
public interface IInvoker
{
    void AddCommand(ICommand command);
    void Execute(IEngine engine);
    void Undo(IEngine engine);
}