
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
    public void SetAbsolutePositionSkin(Point2 position)
    {
        this.Skin.Position = position;
    }
    public void SetAbsolutePositionBody(Point2 position)
    {
        this.Body.Position = position;
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
    public IInvoker Invoker;
    public string Name;
    public void SetUp(IInvoker invoker){Invoker=invoker;}
    public void SetStillObject(Entity stillObject)=> Entity = stillObject;
    public void Move(Point2 v) =>Invoker.AddCommand(new MoveCommand(this,v,(x)=>{x.Get<bool>("CanMove");}));
    public void RelativeRotate(int angle){
        Entity.Skin.Rotate(angle);
        Entity.Body.Rotate(angle);
    }
    public void AbsoluteRotate(int angle)
    {
        Entity.Skin.AbsoluteRotate(angle);
        Entity.Body.AbsoluteRotate(angle);
    }
    public abstract void Loop();
}
