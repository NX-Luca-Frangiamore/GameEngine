using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine : IPhisicsEngine
{
    public BasePhysicsEngine(ObjectResource objectsReferents) : base(objectsReferents)
    {
    }
    public bool AreOverlapped(Object.StillObject body, Point2 v){
            foreach(var o in this.ObjectsReferets.GetAllObjects()){
                if (o == body)continue;
                if (!o.IsTangible) break;
                if (Matrix<object>.IsAOverLapB(o.AbsolutePosition.Plus(o.Body.Position), o.Body.Dimension,
                                              body.AbsolutePosition.Plus(body.Body.Position).Plus(v), body.Body.Dimension))return true;
            }
        return false;
    }
    public override bool Move(Object.StillObject body, Point2 v)
    {
        if (body.IsTangible)
            if (AreOverlapped(body, v)) return false;
        return body.SetAbsolutePosition(body.AbsolutePosition.Plus(v));
    }

    public override bool Traslate(Object.StillObject body, Point2 v)
    {
        return body.SetAbsolutePosition(v);
    }
}