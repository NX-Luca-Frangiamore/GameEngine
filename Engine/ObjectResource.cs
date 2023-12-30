
using System.Reflection;
using Object;
using PhysicsEngine;

namespace Engine;
public class ObjectResource{
    private Dictionary<string, Object.IObject> Objects=new();
    public void AddNewObject(string name, Object.IObject o) => Objects[name]= o;
    public List<Object.IObject> PhGetAllObjects() => Objects.Values.ToList();
    public DumbObject? GetObject(string name) => PhGetObject(name)?.DumbObject;
    public List<DumbObject> GetAllObjects() => Objects.Values.Select(x=>x.DumbObject).ToList();
    public bool DestroyObject(string name) => Objects.Remove(name);
    public Object.IObject? PhGetObject(string name) => Objects.TryGetValue(name, out Object.IObject? o)?o:null;
    public void CollectObject(Type typeLinkAssembly){
        var objectClasses=Assembly.GetAssembly(typeLinkAssembly)!.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IObject).IsAssignableFrom(t));
        foreach(var singleClass in objectClasses){
            string? name = singleClass.FullName;
            IObject? objectCreated = (IObject)Activator.CreateInstance(singleClass)!;
            if (name is null || objectCreated is null) continue;
            AddNewObject(name,objectCreated);
        }    
    }
}