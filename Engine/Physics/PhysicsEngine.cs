using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine : IPhisicsEngine
{
    public BasePhysicsEngine(ObjectResource objectsReferents) : base(objectsReferents){}
    public override bool Traslate(DumbObject body, Point2 v)=>body.SetAbsolutePosition(v);
    public override bool Move(IObject body, Point2 v)
    {
        if (body.DumbObject.Body.IsTangible)
            if (AreRectangleBodyOverlapped(body, v)) return false;
        return body.DumbObject.SetAbsolutePosition(body.DumbObject.AbsolutePosition.Plus(v));
    }//TODO: utilizzare la collisionmatrix
    public bool AreRectangleBodyOverlapped(IObject body, Point2 v){
        bool thereAreOverlapped=false;
        foreach (var o in this.ObjectsReferets.PhGetAllObjects()){
            if (o == body)continue;
            if (!o.DumbObject.Body.IsTangible) break;
            if (Matrix<object>.IsAOverLapB(o.DumbObject.AbsolutePosition.Plus(o.DumbObject.Body.Position), o.DumbObject.Body.Dimension,
                                          body.DumbObject.AbsolutePosition.Plus(body.DumbObject.Body.Position).Plus(v), body.DumbObject.Body.Dimension))
            {

                o.IsInCollision = true;
                o.OnCollisionBy(body.Name);
                body.IsInCollision = false;
                body.OnCollisionBy(o.Name);
                thereAreOverlapped = true;
                
            }
            else { 
                o.IsInCollision=false;
                body.IsInCollision = false;   
            }
        }
        return thereAreOverlapped;
    }
}