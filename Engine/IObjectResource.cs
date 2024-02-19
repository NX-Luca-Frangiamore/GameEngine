using GameEngine.Object;
using GameEngine.Object.Entity;

namespace Engine
{
    public interface IObjectResource
    {
        void AddNewObject(string name, Controller o);
        void CollectObjects(Type typeLinkAssembly);
        bool DestroyObject(string name);
        List<Entity> GetAllObjects();
        Entity? GetObject(string name);
        List<Controller> PhGetAllObjects();
        Controller? PhGetObject(string name);
    }
}