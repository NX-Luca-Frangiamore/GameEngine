using System.Resources;
using Engine;
using Object;
using Utils;

namespace PhysicsEngine;
public abstract class IPhisicsEngine{
    protected ResourceEngine ObjectsReferets;
    public abstract bool Move(Object.Object body,Vector2 v);
    public abstract bool Traslate(Object.Object body, Vector2 v);
    public IPhisicsEngine(ResourceEngine objectsReferents){
        DecoratorForPhysics.PhysicsEngine = this;
        this.ObjectsReferets = objectsReferents;
    }
}  

public class DecoratorForPhysics{
    public Object.Object? @object;
    public static IPhisicsEngine? PhysicsEngine;
    private static DecoratorForPhysics? Istance;
    private DecoratorForPhysics(Object.Object o){
        this.@object= o;
    }
    #region setup
    private DecoratorForPhysics SetObject(Object.Object o){
        this.@object = o;
        return this;
    }
    public static DecoratorForPhysics Init(Object.Object o){
        return Istance is null
            ? new(o)
            : Istance.SetObject(o);
    }
    public static implicit operator Object.Object?(DecoratorForPhysics d){
        return d.@object;
    }
    #endregion 
    public bool Move(Vector2 v) => PhysicsEngine!.Move(@object!,v);
    public bool Translate(Vector2 v) => PhysicsEngine!.Traslate(@object, v);
}