using Engine;
using FluentResults;
using Object;

public class GetKeyboard : ICommand
{
    public GetKeyboard(Controller o,CallBack callBack) : base(o,callBack){}

    public override IResult OnExecution(IEngine engine) => new KeyboardResult(engine.InputEngine.keyPressed);
}
public class KeyboardResult:IResult{
    public KeyboardResult(string? key)=>AddResults("Key",key);
}