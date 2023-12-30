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
    public DumbObject(Point2 dimension, Point2 position) {
        this.Skin = new(dimension,new(0,0));
        this.Body = new(dimension,new(0,0));
        AbsolutePosition = position;
    }
    public bool SetAbsolutePosition(Point2 p){
        AbsolutePosition = p;
        return true;
    }
}
#pragma warning disable CS8618 
public abstract class IObject{
    public DumbObject DumbObject{ get; set; }
    public Engine.IEngine Engine;
    public void SetStillObject(DumbObject stillObject){
        this.DumbObject = stillObject;
    }
    public void Setup(Engine.IEngine engine){
        this.Engine = engine;
        if(DumbObject is null)return ;
    }
    public abstract void Start();
    public abstract void Loop();
    public bool Move(Point2 v) => Engine?.PhisicsEngine?.Move(DumbObject, v) ?? false;
    public bool Translate(Point2 v) => Engine?.PhisicsEngine?.Traslate(DumbObject, v)??false;
}
