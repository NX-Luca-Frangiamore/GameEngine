using Utils;

namespace Engine;
public class ResourcesManager{
    private Dictionary<String,BaseObject> Objects=new();
    public bool AddNewObject(string name, BaseObject o) => Objects.TryAdd(name, o);
    public bool DestroyObject(string name) => Objects.Remove(name);
    public BaseObject? GetObject(string name) => Objects.TryGetValue(name, out BaseObject? value) ? value : null;
    public PixelsMatrix GetComposedPixels(PixelsMatrix canvas){
        PixelsMatrix newMatrix= new(canvas.Dimension,canvas.NCharactersPixel);
        foreach (var o in Objects.Values)
            for (int y = 0; y < o.Sprite.Dimension.y; y++)
                for (int x = 0; x < o.Sprite.Dimension.x; x++)
                {
                    Vector2 pixelPosition = new(x, y);
                    newMatrix.SetPixel(pixelPosition.Plus(o.Position), o.Sprite.GetPixel(pixelPosition));
                }
        return newMatrix;   
    }
    public bool MoveObjectWithV(string name,Vector2 V){
        var o = GetObject(name);
        if (o is null) return false;
        //TODO: da sistemare il controllo delle collisioni, controllare anche le posizioni relative
        foreach(var element in Objects.Where(x=>!x.Value.CanCompenetrate && x.Key!=name).Select(x=>x.Value)){
            if (o.Position == element.Position)
                return false;
        }
        o.Move(V);
        return true; 
    }
}