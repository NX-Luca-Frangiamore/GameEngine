using Engine;
using GameEngine.Engine.InvokerEngine.Abstracts;

namespace GameEngine.Engine.InvokerEngine;
public interface IInvoker
{
    void Execute(ICommand command);
    void Undo();
}