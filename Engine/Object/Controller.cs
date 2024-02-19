using GameEngine.Engine.InvokerEngine;
using GameEngine.Engine.InvokerEngine.Commands;
using Utils;
namespace GameEngine.Object;


#pragma warning disable CS8618 
public abstract class Controller{

    private bool _isActive=true;
    public Entity.Entity Entity{ get; set; }
    public bool IsActive { 
                           get{ return _isActive; }
                           set { _isActive = value;
                                 Entity.Body.IsTangible = value;
                                 Entity.Sprite.IsVisible = value;
                               } 
                         }
    public IInvoker Invoker;
    public string Name;
    public void SetUp(IInvoker invoker){Invoker=invoker;}
    public void SetStillObject(Entity.Entity stillObject)=> Entity = stillObject;
    public void Move(Point2 v) =>Invoker.Execute(new MoveCommand(this,v));
    public void RelativeRotate(int angle)=>Entity.RelativeRotate(angle);
    public void AbsoluteRotate(int angle)=>Entity.AbsoluteRotate(angle);
    public abstract void Loop();
}
