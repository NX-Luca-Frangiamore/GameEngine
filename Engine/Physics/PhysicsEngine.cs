using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine : IPhisicsEngine
{
    public BasePhysicsEngine(ObjectResource objectsReferents) : base(objectsReferents){}
    public override bool Traslate(DumbObject body, Point2 v)=>body.SetAbsolutePosition(v);
    public override bool Move(DumbObject body, Point2 v)
    {
        if (body.Body.IsTangible)
            if (AreRectangleBodyOverlapped(body, v)) return false;
        return body.SetAbsolutePosition(body.AbsolutePosition.Plus(v));
    }
    public bool AreRectangleBodyOverlapped(DumbObject body, Point2 v){
        foreach(var o in this.ObjectsReferets.GetAllObjects()){
            if (o == body)continue;
            if (!o.Body.IsTangible) break;
            if (Matrix<object>.IsAOverLapB(o.AbsolutePosition.Plus(o.Body.Position), o.Body.Dimension,
                                          body.AbsolutePosition.Plus(body.Body.Position).Plus(v), body.Body.Dimension))return true;
        }
        return false;
    }
}