
using System.Reflection;
using GameEngine.Object;
using GameEngine.Object.Entity;
using PhysicsEngine;

namespace Engine;
public class ObjectResource : IObjectResource
{
    private readonly Dictionary<string, Controller> Objects = [];
    public void AddNewObject(string name, Controller o) => Objects[name] = o;
    public List<Controller> GetAllController() => Objects.Values.ToList();
    public bool DestroyObject(string name) => Objects.Remove(name);
    public Controller? GetObject(string name) => Objects.TryGetValue(name, out Controller? o) ? o : null;
    public void CollectObjects(Type typeLinkAssembly)
    {
        var objectClasses = Assembly.GetAssembly(typeLinkAssembly)!.GetTypes().Where(t => t.IsClass && !t.IsAbstract &&t.IsPublic && typeof(Controller).IsAssignableFrom(t));
        foreach (var singleClass in objectClasses)
        {
            string? name = singleClass.FullName;
            Controller? objectCreated = (Controller)Activator.CreateInstance(singleClass)!;
            if (name is null || objectCreated is null) continue;
            objectCreated.Entity.Name = name;
            AddNewObject(name, objectCreated);
        }
    }
}