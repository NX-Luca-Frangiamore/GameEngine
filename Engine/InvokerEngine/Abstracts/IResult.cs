namespace GameEngine.Engine.InvokerEngine.Abstracts;

public abstract class IResult { 
    public Dictionary<string,object>Results=new();
    public void AddResults<T>(string key,T data)=>Results[key]=data!;
    public T? Get<T>(string key){
        if(!Results.ContainsKey(key))return default;
        try{
            return (T)Results[key];
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