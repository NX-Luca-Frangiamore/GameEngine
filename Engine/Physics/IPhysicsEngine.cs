using System.Resources;
using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine{
    public abstract bool AreThereCollisions(Controller body,Point2 position);
    public abstract void Traslate(Entity body, Point2 v);
}
