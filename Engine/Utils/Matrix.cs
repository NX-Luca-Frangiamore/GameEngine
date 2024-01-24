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

    protected T? GetElement(Point2 p){
        if (!CanElementBeInMatrix(p)) return Default_value;
        return Elements.TryGetValue(p, out T? value) ? value : Default_value;
    }

    protected bool SetElement(Point2 p,T value){
        if (!CanElementBeInMatrix(p)) return false;
        Elements[p] = value;
        return true;
    }

    protected bool DeleteElement(Point2 p) => Elements.Remove(p);

    private bool CanElementBeInMatrix(Point2 p){
        if (p.x < 0 && p.x >= this.Dimension.x) return false;
        if (p.y < 0 && p.y >= this.Dimension.y) return false;
        return true;
    }
    protected  Dictionary<Point2, T> GetMatrixWithRotationOf90() {
        Dictionary<Point2, T> matrix = new();
        for (int y = 0; y < Dimension.y; y++)
            for (int x = 0; x < Dimension.x; x++){
                if( this.GetElement(new(x, y)) is T v){
                    Point2 nuovaPosizione = new Point2(y, Dimension.x - x - 1);
                    matrix[nuovaPosizione] = v;
                }
            }
        return matrix;

    }
    public static bool IsAOverLapB(Point2 positionA,Point2 sizeA,Point2 positionB,Point2 sizeB){
        bool xOverlap = positionA.x < positionB.x + sizeB.x &&
                        positionB.x < positionA.x + sizeA.x;

        bool yOverlap = positionA.y < positionB.y + sizeB.y &&
                        positionB.y < positionA.y + sizeA.y;

        return xOverlap && yOverlap;
    }
    
}