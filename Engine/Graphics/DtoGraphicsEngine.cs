using Utils;
namespace Graphics;
public class DtoGraphicsEngine{
    public readonly Sprite Sprite;
    public readonly Point2 AbsolutePosition;

    public DtoGraphicsEngine(Sprite sprite,Point2 absolutePosition){
        this.Sprite = sprite;
        this.AbsolutePosition = absolutePosition;
    }
}