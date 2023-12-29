using System.Dynamic;
using System.Net.NetworkInformation;
using Engine;
using Graphics;
using PhysicsEngine;
using Utils;
namespace Object;

public class StillObject{
    public Sprite Skin{ get; protected set; }
    public Body Body{ get; protected set; }
    public bool IsTangible { get; protected set; } = true;
    public Point2 AbsolutePosition{ get; set; }
    public StillObject(Point2 dimension, Point2 position) {
        this.Skin = new(dimension,new(0,0));
        this.Body = new(dimension,new(0,0));
        this.AbsolutePosition = position;        
    }
    public bool SetAbsolutePosition(Point2 p){
        AbsolutePosition = p;
        return true;
    }
}
#pragma warning disable CS8618 
public abstract class PhysicsObject{
    public StillObject StillObject;
    public Engine.Engine Engine;
    public void SetStillObject(StillObject stillObject){
        this.StillObject = stillObject;
    }
    public void BeforeLoop(Engine.Engine engine){
        this.Engine = engine;
        if(StillObject is null)return ;
        Loop();
    }
    public abstract void Loop();
    public bool Move(Point2 v) => Engine?.PhisicsEngine?.Move(StillObject, v) ?? false;
    public bool Translate(Point2 v) => Engine?.PhisicsEngine?.Traslate(StillObject, v)??false;
}
