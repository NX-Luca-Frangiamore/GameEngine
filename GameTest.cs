using GameEngine.Engine.Input;
using GameEngine.Engine.InvokerEngine.Commands;
using GameEngine.Object;
using GameEngine.Object.Entity;
using Utils;

Engine.IEngine.StartEngine<Nave>()
    .SetDelayInput(50)
    .SetDelayFrame(100)
    .Start();

public class Nave : Controller
{
    private Point2 Speed = new(0, 0);
    private int nBullet = 0;
    public Nave()
    {
        Entity stillObject = Entity.New(3, new(1, 1));
        DtoCreateEntity dto = new DtoCreateEntity(3);
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.Rows.Add(new(3) { Els = ["", "o", ""] });
        dto.SetInfo(new(1, 2), new InfoPixel() { Color = "red" });

        SetStillObject(EntityFactory.CreateEntity(new(1, 1), dto));

    }

    public override void Loop()
    {
        KeyManager.IsThereThen("r", () => Invoker.Undo());

        ActWithInput(this);
        KeyManager.IsThereThen("space", () =>
        {
            var bullet = new Bullet(this.Entity.AbsolutePosition.Plus(new(1, 1)), MappingAngleToVector2(), Entity.Name);
            Invoker.Execute(new CreateControllerCommand(this, "bullet" + nBullet, bullet));
            nBullet++;
        });

        Invoker.Execute(new MoveCommand(this, Speed));
    }

    private void ActWithInput(Controller c)
    {
        Speed = new(0, 0);
        KeyManager.IsThereThen("a", () =>
        {
            c.Invoker.Execute(new AbsoluteRotateCommand(c, 270));
            Speed = Speed.Plus(new(-1, 0));
        }).Or(
        () => KeyManager.IsThereThen("d", () =>
        {
            c.Invoker.Execute(new AbsoluteRotateCommand(c, 90));
            Speed = Speed.Plus(new(1, 0));
        })).Or(
        () => KeyManager.IsThereThen("w", () =>
        {
            c.Invoker.Execute(new AbsoluteRotateCommand(c, 0));
            Speed = Speed.Plus(new(0, 1));
        })).Or(
        () => KeyManager.IsThereThen("s", () =>
        {
            c.Invoker.Execute(new AbsoluteRotateCommand(c, 180));
            Speed = Speed.Plus(new(0, -1));
        }));
    }

    private Point2 MappingAngleToVector2() => Entity.Sprite.Angle switch
    {
        0 => new Point2(0, -1),
        90 => new Point2(-1, 0),
        180 => new Point2(0, 1),
        270 => new Point2(1, 0),
        _ => throw new NotImplementedException(),
    };
}

internal class Bullet : Controller
{
    private Point2 Speed;
    private Point2 Init;
    private string Owner;
    public Bullet(Point2 position, Point2 speed, string owner)
    {
        Owner = owner;
        Init = position;
        var StillObject = Entity.New(1, position);
        StillObject.Sprite.Data.FillWith(new Pixel("o", new InfoPixel { Color = "green" }));
        StillObject.Sprite.IsVisible = true;
        StillObject.Body.Data.FillWith(true);
        SetStillObject(StillObject);
        Speed = new Point2(-speed.x * 2, -speed.y * 2);
        Entity.Body.CollideBut(Owner);
    }

    public override void Loop()
    {
        Invoker.Execute(new MoveCommand(this, Speed, (x =>
        {
            if (x.CanMove)
                Entity.Body.CollideWith(Owner);
        })));
        if (Init.Minus(Entity.AbsolutePosition).GetModule() > 10)
            Invoker.Execute(new DestroyMeCommand(this));
    }
}

public class Wall : Controller
{
    public Wall()
    {
        var StillObject = Entity.New(5, new(8, 1));
        StillObject.Sprite.Data.FillWith("*");
        StillObject.Body.Data.FillWith(true);
        SetStillObject(StillObject);
    }
}


