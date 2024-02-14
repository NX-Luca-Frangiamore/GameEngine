using System.Dynamic;
using System.Net.NetworkInformation;
using Engine;
using Graphics;
using Invoker;
using PhysicsEngine;
using Utils;
namespace Object;

public class Entity{
    public Sprite Skin{ get; private set; }
    public Body Body{ get; private set; }
    public Point2 AbsolutePosition{ get; private set; }
   
    public bool IsInCollision;
    public Entity(Point2 dimension, Point2 position) {
        this.Skin = new(dimension,new(0,0));
        this.Body = new(dimension,new(0,0));
        AbsolutePosition = position;
    }
    public void SetAbsolutePosition(Point2 p)=>AbsolutePosition = p;
}
#pragma warning disable CS8618 
public abstract class Controller{

    private bool _isActive=true;
    public Entity Entity{ get; set; }
    public bool IsActive { 
                           get{ return _isActive; }
                           set { _isActive = value;
                                 Entity.Body.IsTangible = value;
                                 Entity.Skin.IsVisible = value;
                               } 
                         }
    public Invoker.Invoker Invoker;
    public string Name;
    public void SetUp(Invoker.Invoker invoker){Invoker=invoker;}
    public void SetStillObject(Entity stillObject)=> this.Entity = stillObject;
    public void Move(Point2 v) =>Invoker.Add(new MoveCommand(this,v,(x)=>{x.Get<bool>("CanMove");}));
    public void Rotate(int angle){
        Entity.Skin.RotateSkin(angle);
        Entity.Body.RotateBody(angle);
    }
    public abstract void Loop();
}
