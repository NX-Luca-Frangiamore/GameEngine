using System.Resources;
using Engine;
using GameEngine.Object.Entity;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine
{
    public abstract CollisionInfo AreThereCollisions(Entity entity, Point2 move);
    public abstract void Traslate(Entity body, Point2 v);
}
public class CollisionInfo
{
    public List<Object> Collisions = [];
    public Object? CrushedWith = null;
    public class Object(string name, bool? isPermeable = false)
    {
        public string Name = name;
        public bool IsPermeable = isPermeable ?? false;
    }
}
