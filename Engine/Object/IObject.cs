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
   
    public bool IsInCollision;
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

    private bool _isActive=true;
    public bool IsActive { get{ return _isActive; }
                           set { _isActive = value;
                            DumbObject.Body.IsTangible = value;
                            DumbObject.Skin.IsVisible = value;
                         } 
    }
    public DumbObject DumbObject{ get; set; }
    public Invoker.Invoker Invoker;
    public string Name;
    public void SetUp(Invoker.Invoker invoker){Invoker=invoker;}
    public void SetStillObject(DumbObject stillObject){
        this.DumbObject = stillObject;
    }
    public abstract void Loop();
    public void Move(Point2 v) =>Invoker.Add(new MoveCommand(this,v,(x)=>{x.Get<bool>("CanMove");}));
    //public void Traslate(Point2 v) => ;
}
