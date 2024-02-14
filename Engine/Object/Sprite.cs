using Graphics;
using Utils;

public class Sprite
{
    public bool IsVisible=true;
    public Point2 Position;
    public PixelsMatrix Data { get; private set; }
    public int Angle { get; private set; }
    public Sprite(Point2 dimension,Point2 position){
        Position = position;
        Data = new(dimension, 1);
    }
    public void RotateSkin(int angle) {
        if(angle%90!= 0) return;
        int turn = angle / 90;
        for(int i = 0; i < turn; i++) {
            Data = Data.GetCollisionMatrixRotatedOf90();
        }
    }
}