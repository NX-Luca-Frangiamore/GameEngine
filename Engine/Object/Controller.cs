
using GameEngine.Engine.InvokerEngine;
using GameEngine.Engine.InvokerEngine.Commands;
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
    public Entity(Sprite skin, Body body,Point2 position)
    {
        this.Skin = skin; this.Body = body;
        AbsolutePosition = position;
    }
    public static Entity New(int dimension, Point2 position)
        =>new Entity(new(dimension, dimension), position);

    public Entity Clone()=>
        new(Skin.Clone(), Body.Clone(), AbsolutePosition);

    public void SetAbsolutePositionSkin(Point2 position)
    {
        this.Skin.Position = position;
    }
    public void SetAbsolutePositionBody(Point2 position)
    {
        this.Body.Position = position;
    }
    public void SetAbsolutePosition(Point2 p)=>AbsolutePosition = p;
    public void RelativeRotate(int angle)
    {
        Skin.Data.RelativeRotate(angle);
        Body.Data.RelativeRotate(angle);
    }
    public void AbsoluteRotate(int angle)
    {
        Skin.AbsoluteRotate(angle);
        Body.AbsoluteRotate(angle);
    }
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
    public IInvoker Invoker;
    public string Name;
    public void SetUp(IInvoker invoker){Invoker=invoker;}
    public void SetStillObject(Entity stillObject)=> Entity = stillObject;
    public void Move(Point2 v) =>Invoker.Execute(new MoveCommand(this,v));
    public void RelativeRotate(int angle)=>Entity.RelativeRotate(angle);
    public void AbsoluteRotate(int angle)=>Entity.AbsoluteRotate(angle);
    public abstract void Loop();
}
