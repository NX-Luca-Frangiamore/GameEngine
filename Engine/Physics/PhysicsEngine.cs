using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine(ObjectResource ObjectsReferents) : IPhisicsEngine
{
    public override void Traslate(Entity body, Point2 v)=>body.SetAbsolutePosition(v);

    public override bool AreThereCollisions(Entity entity, Point2 move)
    {
        Point2 absolutePositionBody= entity.AbsolutePosition.Plus(entity.Body.Position).Plus(move);
        if (!entity.Body.IsTangible) return false;
        foreach(var part in entity.Body.Data.Elements){
            if(!part.Value)continue;
          
            var absolutePositionPart=absolutePositionBody.Plus(part.Key);
            
            foreach(var otherObject in ObjectsReferents.GetAllObjects()){
                if(otherObject== entity) continue;
                if (!otherObject.Body.IsTangible)continue;
                if (otherObject.Body.Data.Elements.Any(x=>x.Value && x.Key.Plus(otherObject.AbsolutePosition.Plus(otherObject.Body.Position))==absolutePositionPart))
                    return true;
            }
        }
        return false;
    }
}