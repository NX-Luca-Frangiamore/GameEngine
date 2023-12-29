
using Object;
using PhysicsEngine;

namespace Engine;
public class ObjectResource{
    private Dictionary<string,PhysicsObject> Objects=new();
    public bool AddNewObject(string name, PhysicsObject o) => Objects.TryAdd(name, o);
    public bool DestroyObject(string name) => Objects.Remove(name);
    public PhysicsObject? PhGetObject(string name) => Objects.TryGetValue(name, out PhysicsObject? o)?o:null;
    public List<PhysicsObject> PhGetAllObjects() => Objects.Values.ToList();
    public StillObject? GetObject(string name) => PhGetObject(name)?.StillObject;
    public List<StillObject> GetAllObjects() => Objects.Values.Select(x=>x.StillObject).ToList();
}