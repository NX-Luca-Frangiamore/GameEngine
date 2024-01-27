using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine(ObjectResource ObjectsReferents) : IPhisicsEngine
{
    public override bool Traslate(DumbObject body, Point2 v)=>body.SetAbsolutePosition(v);

    public override bool AreThereCollisions(IObject body, Point2 move)
    {
        Point2 absolutePositionBody=body.DumbObject.AbsolutePosition.Plus(body.DumbObject.Body.Position).Plus(move);
        if (!body.DumbObject.Body.IsTangible) return false;
        foreach(var part in body.DumbObject.Body.Parts.Elements){
            if(!part.Value)continue;
          
            var absolutePositionPart=absolutePositionBody.Plus(part.Key);
            
            foreach(var otherObject in ObjectsReferents.GetAllObjects()){
                if(otherObject==body.DumbObject)continue;
                if (!otherObject.Body.IsTangible)continue;
                if (otherObject.Body.Parts.Elements.Any(x=>x.Value && x.Key.Plus(otherObject.AbsolutePosition.Plus(otherObject.Body.Position))==absolutePositionPart))
                    return true;
            }
        }
        return false;
    }
}