using Utils;

public class Matrix<T>{
    protected Dictionary<Vector2, T> Elements{ get;set; }
    public Vector2 Dimension { get; private set; }
    protected Matrix(Vector2 dimension){
        Elements = new();
        Dimension = dimension;
    }

    protected T? Get(Vector2 p){
        if (!IsInMatrix(p)) return default(T);
        return Elements.TryGetValue(p, out T? value) ? value : default(T);
    }

    protected bool Set(Vector2 p,T value){
        if (!IsInMatrix(p)) return false;
        Elements[p] = value;
        return true;
    }

    protected bool Delete(Vector2 p) => Elements.Remove(p);

    private bool IsInMatrix(Vector2 p){

        if (p.x < 0 && p.x >= this.Dimension.x) return false;
        if (p.y < 0 && p.y >= this.Dimension.y) return false;
        return true;
    }

}