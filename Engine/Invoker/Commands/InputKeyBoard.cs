using Engine;
using Object;

public class GetKeyboard : ICommand
{
    public GetKeyboard(IObject o) : base(o){}

    public override IResult Execute(IEngine engine)
    {
        return new ResultKeyboard(engine.InputEngine.keyPressed);
    }
}
public class ResultKeyboard:IResult{
    public ResultKeyboard(string? key){
        Specific=key;
    }
}