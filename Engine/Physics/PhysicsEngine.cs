using Object;
using Utils;

namespace PhysicsEngine;
public class PhysicsEngine : IPhisicsEngine
{
    public bool Move(Object.Object @object,Vector2 v)
    {
        return @object.SetAbsolutePosition(@object.AbsolutePosition.Plus(v));
    }
}