using Engine;
using FluentResults;
using Object;

public class GetKeyboard : ICommand
{
    public GetKeyboard(IObject o,CallBack callBack) : base(o,callBack){}

    public override KeyboardResult OnExecution(IEngine engine)
    {
        return new KeyboardResult{
            Key=engine.InputEngine.keyPressed
        };
    }
}
public class KeyboardResult:IResult{
  public new string? Key{get;init;}
}