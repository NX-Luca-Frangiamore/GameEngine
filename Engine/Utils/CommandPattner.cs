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
    public Dictionary<string,object>Results=new();
    public void AddResults<T>(string key,T data)=>Results[key]=data!;
    public T? Get<T>(string key){
        if(!Results.ContainsKey(key))return default;
        try{
            return (T)Results[key];
        }
        catch(Exception _){
            return default;
        }
    }
    public override string ToString(){
        return Results.ToString()!;
    }

}