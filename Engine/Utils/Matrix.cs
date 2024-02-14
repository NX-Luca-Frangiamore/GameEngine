using Utils;

public class Matrix<T>{
    public Dictionary<Point2, T> Elements{ get;protected set; }
    public Point2 Dimension { get; private set; }
    private T Default_value;
    protected Matrix(Point2 dimension,T default_value){
        Elements = new();
        Dimension = dimension;
        Default_value = default_value;
    }
    protected Matrix(Point2 dimension, T default_value, Dictionary<Point2, T> elements)
    {
        Elements = elements;
        Dimension = dimension;
        Default_value = default_value;
    }

    protected T? GetElement(Point2 p){
        if (!CanElementBeInMatrix(p)) return Default_value;
        return Elements.TryGetValue(p, out T? value) ? value : Default_value;
    }

    protected bool SetElement(Point2 p,T value){
        if (!CanElementBeInMatrix(p)) return false;
        Elements[p] = value;
        return true;
    }
    public void ExecuteForAllElement(Action<T> act)
    {
        for (int y = 0; y < Dimension.y; y++)
            for (int x = 0; x < Dimension.x; x++)
                act(this.Elements[new(y, x)]);
    }
    public void AddInAllElement(T date)
    {
        for (int y = 0; y < Dimension.y; y++)
            for (int x = 0; x < Dimension.x; x++)
                SetElement(new(y, x), date);
    }
    protected bool DeleteElement(Point2 p) => Elements.Remove(p);

    private bool CanElementBeInMatrix(Point2 p){
        if (p.x < 0 && p.x >= this.Dimension.x) return false;
        if (p.y < 0 && p.y >= this.Dimension.y) return false;
        return true;
    }
    public void Rotate(int angle)
    {
        if (angle % 90 != 0) return;
        int turn = angle / 90;
        for (int i = 0; i< turn; i++)
            RotateBy90();
    }
    public  void RotateBy90() {
        Dictionary<Point2, T> newElements = new();
        for (int y = 0; y < Dimension.y; y++)
            for (int x = 0; x < Dimension.x; x++){
                if( this.GetElement(new(x, y)) is T v){
                    Point2 nuovaPosizione = new Point2(y, Dimension.x - x - 1);
                    newElements[nuovaPosizione] = v;
                }
            }
        Dimension = new(Dimension.y, Dimension.x);
        Elements = newElements;

    }
    public static bool IsAOverLapB(Point2 positionA,Point2 sizeA,Point2 positionB,Point2 sizeB){
        bool xOverlap = positionA.x < positionB.x + sizeB.x &&
                        positionB.x < positionA.x + sizeA.x;

        bool yOverlap = positionA.y < positionB.y + sizeB.y &&
                        positionB.y < positionA.y + sizeA.y;

        return xOverlap && yOverlap;
    }
    
}