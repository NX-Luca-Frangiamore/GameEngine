
using Object;
using PhysicsEngine;

namespace Engine;
public class ObjectResource{
    private Dictionary<string, Object.Object> Objects=new();
    public bool AddNewObject(string name, Object.Object o) => Objects.TryAdd(name, o);
    public List<Object.Object> PhGetAllObjects() => Objects.Values.ToList();
    public DumbObject? GetObject(string name) => PhGetObject(name)?.DumbObject;
    public List<DumbObject> GetAllObjects() => Objects.Values.Select(x=>x.DumbObject).ToList();
    public bool DestroyObject(string name) => Objects.Remove(name);
    public Object.Object? PhGetObject(string name) => Objects.TryGetValue(name, out Object.Object? o)?o:null;
}