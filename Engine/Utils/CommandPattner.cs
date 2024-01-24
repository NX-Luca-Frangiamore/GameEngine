using Engine;
using Object;
public abstract class ICommand{
    public IObject o{get;private set;}
    public string FromWho{get;init;}
    public ICommand(IObject o){
        this.o=o;
        FromWho=o.Name;
    }
    public abstract IResult  Execute(IEngine engine);
}
public abstract class IResult{
    public string? Name;
    public string? Specific;
}
public class EmptyResult:IResult{}