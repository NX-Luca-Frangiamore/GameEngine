using System.Dynamic;
using System.Net.NetworkInformation;
using Engine;
using Graphics;
using Invoker;
using PhysicsEngine;
using Utils;
namespace Object;

public class DumbObject{
    public Sprite Skin{ get; private set; }
    public Body Body{ get; private set; }
    public Point2 AbsolutePosition{ get; private set; }
    private bool _isActive=true;
   
    public bool IsActive { get{ return _isActive; }
                           set { _isActive = value;
                               Body.IsTangible = value;
                               Skin.IsVisible = value;
                         } 
    }
    public DumbObject(Point2 dimension, Point2 position) {
        this.Skin = new(dimension,new(0,0));
        this.Body = new(new CollisionMatrix(dimension),new(0,0));
        AbsolutePosition = position;
    }
    public bool SetAbsolutePosition(Point2 p){
        AbsolutePosition = p;
        return true;
    }
    public void RotateOf90(){
        Skin.RotateSkinOf90();
        Body.RotateBodyOf90();
    }
}
#pragma warning disable CS8618 
public abstract class IObject{
    public DumbObject DumbObject{ get; set; }
    public Invoker.Invoker Invoker;
    public string Name;
    public bool IsInCollision;
    public void SetUp(Invoker.Invoker invoker){Invoker=invoker;}
    public void SetStillObject(DumbObject stillObject){
        this.DumbObject = stillObject;
    }
    public abstract void Loop();
    public virtual void OnCollisionBy(string nameObject) { }
    public void Move(Point2 v) =>Invoker.Add(new MoveCommand(this,v));
    //public void Traslate(Point2 v) => ;
}
