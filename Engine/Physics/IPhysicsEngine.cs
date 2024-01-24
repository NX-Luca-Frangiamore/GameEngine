using System.Resources;
using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine{
    public abstract bool AreThereCollisions(IObject body,Point2 position);
    public abstract bool Traslate(DumbObject body, Point2 v);
}
