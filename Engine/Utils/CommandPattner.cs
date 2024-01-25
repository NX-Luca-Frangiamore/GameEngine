using Engine;
using Object;

public delegate void CallBack(IResult result);
public abstract class ICommand{
    public IObject o{get;private set;}
    public string FromWho{get;init;}
    private CallBack CallBack;
    public ICommand(IObject o,CallBack? callBack=default){
        this.o=o;
        FromWho=o.Name;
        CallBack = callBack??((x)=>{});
    }
    public void Execute(IEngine engine){

        CallBack(OnExecution(engine));
    }
    public abstract IResult OnExecution(IEngine engine);
}
public abstract class IResult { 
    public virtual string? Key{get;init;}
    public virtual bool? CanMove{get;init;}
    public virtual string? BlockedFrom{get;init;}
    public virtual string? Description{get;init;}

}