using System.Dynamic;
using System.Net.NetworkInformation;
using Engine;
using Graphics;
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
        this.Body = new(dimension,new(0,0));
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
    public Engine.IEngine Engine;
    public string Name;
    public bool IsInCollision;
    public void SetStillObject(DumbObject stillObject){
        this.DumbObject = stillObject;
    }
    public void Setup(Engine.IEngine engine){
        this.Engine = engine;
        if(DumbObject is null)return ;
    }
    public abstract void Loop();
    public virtual void OnCollisionBy(string nameObject) { }
    public bool Move(Point2 v) => Engine?.PhisicsEngine?.Move(this, v) ?? false;
    public bool Traslate(Point2 v) => Engine?.PhisicsEngine?.Traslate(DumbObject, v)??false;
}
