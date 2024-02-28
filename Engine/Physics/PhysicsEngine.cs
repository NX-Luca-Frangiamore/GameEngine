using Engine;
using GameEngine.Object.Entity;
using System.Linq;
using Utils;

namespace PhysicsEngine;
public class BasePhysicsEngine(ObjectResource ObjectsReferents) : IPhisicsEngine
{
    public override void Traslate(Entity body, Point2 v)=>body.SetAbsolutePosition(v);

    public override CollisionInfo AreThereCollisions(Entity entity, Point2 move)
    {
        Point2 absolutePositionBody= entity.AbsolutePosition.Plus(entity.Body.Position).Plus(move);
        CollisionInfo collisionInfo = new CollisionInfo();
        if (!entity.Body.IsTangible) return collisionInfo;
        foreach(var part in entity.Body.Data.Elements){
            if(!part.Value)continue;
          
            var absolutePositionPart=absolutePositionBody.Plus(part.Key);
            
            foreach(var otherObject in ObjectsReferents.GetAllController().Select(x=>x.Entity)){
                if(otherObject== entity) continue;
                if (entity.Body.Expect.Contains(otherObject.Name)) continue;
                if (otherObject.Body.Expect.Contains(entity.Name)) continue;
                if (!otherObject.Body.IsTangible)continue;
                if (!otherObject.Body.IsPermeable)
                {
                    collisionInfo.Collisions.Add(new(otherObject.Name, true));
                    continue;
                }
                if (otherObject.Body.Data.Elements.Any(x => x.Value && x.Key.Plus(otherObject.AbsolutePosition.Plus(otherObject.Body.Position)) == absolutePositionPart))
                {
                    collisionInfo.CrushedWith = new(otherObject.Name);
                    return collisionInfo;
                }
            }
        }
        return collisionInfo;
    }
}