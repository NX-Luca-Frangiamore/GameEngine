using Engine;
using FluentResults;
using GameEngine.Engine.InvokerEngine.Abstracts;
using GameEngine.Object;
namespace GameEngine.Engine.InvokerEngine.Commands;

public class GetKeyboard : ICommand
{
    public GetKeyboard(Controller o,CallBack callBack) : base(o,callBack){}

    public override IResult OnExecution(IEngine engine) => new KeyboardResult(engine.InputEngine.keyPressed);

    public override void OnUndo(IEngine engine)=> new DefaultResult();
}
public class KeyboardResult:IResult{
    public KeyboardResult(string? key)=>AddResults("Key",key);

}