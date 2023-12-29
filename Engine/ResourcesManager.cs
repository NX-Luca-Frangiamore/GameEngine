
using PhysicsEngine;

namespace Engine;
public class ResourceEngine{
    private Dictionary<String,Object.Object> Objects=new();
    public bool AddNewObject(string name, Object.Object o) => Objects.TryAdd(name, o);
    public bool DestroyObject(string name) => Objects.Remove(name);
    public DecoratorForPhysics? PhGetObject(string name) => DecoratorForPhysics.Init(Objects[name]);
    public List<DecoratorForPhysics> PhGetAllObjects() => Objects.Values.Select(x=>DecoratorForPhysics.Init(x)).ToList();
    public Object.Object? GetObject(string name) => Objects[name];
    public List<Object.Object> GetAllObjects() => Objects.Values.ToList();
}