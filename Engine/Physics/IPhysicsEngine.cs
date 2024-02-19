using System.Resources;
using Engine;
using GameEngine.Object.Entity;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine{
    public abstract bool AreThereCollisions(Entity entity, Point2 move);
    public abstract void Traslate(Entity body, Point2 v);
}
