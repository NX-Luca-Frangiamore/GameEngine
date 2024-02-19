
using System.Reflection;
using GameEngine.Object;
using GameEngine.Object.Entity;
using PhysicsEngine;

namespace Engine;
public class ObjectResource : IObjectResource
{
    private Dictionary<string, Controller> Objects = new();
    public void AddNewObject(string name, Controller o) => Objects[name] = o;
    public List<Controller> PhGetAllObjects() => Objects.Values.ToList();
    public Entity? GetObject(string name) => PhGetObject(name)?.Entity;
    public List<Entity> GetAllObjects() => Objects.Values.Select(x => x.Entity).ToList();
    public bool DestroyObject(string name) => Objects.Remove(name);
    public Controller? PhGetObject(string name) => Objects.TryGetValue(name, out Controller? o) ? o : null;
    public void CollectObjects(Type typeLinkAssembly)
    {
        var objectClasses = Assembly.GetAssembly(typeLinkAssembly)!.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(Controller).IsAssignableFrom(t));
        foreach (var singleClass in objectClasses)
        {
            string? name = singleClass.FullName;
            Controller? objectCreated = (Controller)Activator.CreateInstance(singleClass)!;
            if (name is null || objectCreated is null) continue;
            objectCreated.Name = name;
            AddNewObject(name, objectCreated);
        }
    }
}