
using System.Reflection;
using Object;
using PhysicsEngine;

namespace Engine;
public class ObjectResource{
    private Dictionary<string, IObject> Objects=new();
    public void AddNewObject(string name, IObject o) => Objects[name]= o;
    public List<IObject> PhGetAllObjects() => Objects.Values.ToList();
    public DumbObject? GetObject(string name) => PhGetObject(name)?.DumbObject;
    public List<DumbObject> GetAllObjects() => Objects.Values.Select(x=>x.DumbObject).ToList();
    public bool DestroyObject(string name) => Objects.Remove(name);
    public IObject? PhGetObject(string name) => Objects.TryGetValue(name, out IObject? o)?o:null;
    public void CollectObjects(Type typeLinkAssembly){
        var objectClasses=Assembly.GetAssembly(typeLinkAssembly)!.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IObject).IsAssignableFrom(t));
        foreach(var singleClass in objectClasses){
            string? name = singleClass.FullName;
            IObject? objectCreated = (IObject)Activator.CreateInstance(singleClass)!;
            if (name is null || objectCreated is null) continue;
            AddNewObject(name,objectCreated);
        }    
    }
}