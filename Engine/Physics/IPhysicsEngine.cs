using System.Resources;
using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine{
    protected ObjectResource ObjectsReferets;
    public abstract bool Move(Object.DumbObject body,Point2 v);
    public abstract bool Traslate(Object.DumbObject body, Point2 v);
    public IPhisicsEngine(ObjectResource objectsReferents){
        this.ObjectsReferets = objectsReferents;
    }
}  