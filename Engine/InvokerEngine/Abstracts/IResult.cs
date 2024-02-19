namespace GameEngine.Engine.InvokerEngine.Abstracts;

public abstract class IResult { 
    public Dictionary<string,object>Results=[];
    public void AddResults<T>(string key,T data)=>Results[key]=data!;
    public T? Get<T>(string key){
        if(!Results.TryGetValue(key, out object? value)) return default;
        try{
            return (T)value;
        }
        catch (Exception)
        {
            return default;
        }
    }
    public override string ToString(){
        return Results.ToString()!;
    }

}
public class DefaultResult : IResult { 
}