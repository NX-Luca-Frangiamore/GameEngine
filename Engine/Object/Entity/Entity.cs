using Utils;

namespace GameEngine.Object.Entity;
public class Entity
{
    public Sprite Sprite { get; private set; }
    public Body Body { get; private set; }
    public Point2 AbsolutePosition { get; private set; }
    public string Name;
    public bool IsInCollision;
    public Entity(Point2 dimension, Point2 position)
    {
        Sprite = new(dimension, new(0, 0));
        Body = new(dimension, new(0, 0));
        AbsolutePosition = position;
    }
    public Entity(Sprite skin, Body body, Point2 position)
    {
        Sprite = skin; Body = body;
        AbsolutePosition = position;
    }
    public static Entity New(int dimension, Point2 position)
        => new Entity(new(dimension, dimension), position);

    public Entity Clone() =>
        new(Sprite.Clone(), Body.Clone(), AbsolutePosition);

    public void SetAbsolutePositionSkin(Point2 position)
    {
        Sprite.Position = position;
    }
    public void SetAbsolutePositionBody(Point2 position)
    {
        Body.Position = position;
    }
    public void SetAbsolutePosition(Point2 p) => AbsolutePosition = p;

    public void RelativeRotate(int angle)
    {
        Sprite.RelativeRotate(angle);
        Body.RelativeRotate(angle);
    }
    public void AbsoluteRotate(int angle)
    {
        Sprite.AbsoluteRotate(angle);
        Body.AbsoluteRotate(angle);
    }
}

