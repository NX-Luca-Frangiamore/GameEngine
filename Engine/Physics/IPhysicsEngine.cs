using Object;
using Utils;

namespace PhysicsEngine;
public interface IPhisicsEngine{
    public bool Move(Object.Object body,Vector2 v);
}