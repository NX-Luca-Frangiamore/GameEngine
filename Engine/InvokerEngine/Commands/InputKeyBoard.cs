using Engine;
using FluentResults;
using GameEngine.Engine.InvokerEngine.Abstracts;
using Object;
namespace GameEngine.Engine.InvokerEngine.Commands;

public class GetKeyboard : ICommand
{
    public GetKeyboard(Controller o,CallBack callBack) : base(o,callBack){}

    public override IResult OnExecution(IEngine engine) => new KeyboardResult(engine.InputEngine.keyPressed);

    public override IResult OnUndo(IEngine engine)=> new KeyboardResult();
}
public class KeyboardResult:IResult{
    public KeyboardResult(string? key)=>AddResults("Key",key);
    public KeyboardResult() => AddResults("Key", default(string));

}