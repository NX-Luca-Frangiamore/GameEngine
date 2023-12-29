
namespace Engine;
public partial class Engine{
    private Dictionary<String,Object.Object> Objects=new();
    public bool AddNewObject(string name, Object.Object o) => Objects.TryAdd(name, o);
    public bool DestroyObject(string name) => Objects.Remove(name);
    public Object.Object? GetObject(string name) => Objects.TryGetValue(name, out Object.Object? value) ? value : null;
    public List<Object.Object> GetAllObjects() => Objects.Values.ToList();
}