using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine : IPhisicsEngine
{
    public BasePhysicsEngine(ResourceEngine objectsReferents) : base(objectsReferents)
    {
    }

    public override bool Move(Object.Object body, Vector2 v)
    {
        throw new NotImplementedException();
    }

    public override bool Traslate(Object.Object body, Vector2 v)
    {
        throw new NotImplementedException();
    }
}