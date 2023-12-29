using Utils;

public class Matrix<T>{
    protected Dictionary<Point2, T> Elements{ get;set; }
    public Point2 Dimension { get; private set; }
    protected Matrix(Point2 dimension){
        Elements = new();
        Dimension = dimension;
    }

    protected T? GetElement(Point2 p){
        if (!IsElementInMatrix(p)) return default(T);
        return Elements.TryGetValue(p, out T? value) ? value : default(T);
    }

    protected bool SetElement(Point2 p,T value){
        if (!IsElementInMatrix(p)) return false;
        Elements[p] = value;
        return true;
    }

    protected bool DeleteElement(Point2 p) => Elements.Remove(p);

    private bool IsElementInMatrix(Point2 p){

        if (p.x < 0 && p.x >= this.Dimension.x) return false;
        if (p.y < 0 && p.y >= this.Dimension.y) return false;
        return true;
    }
   public static bool IsAOverLapB(Point2 positionA,Point2 sizeA,Point2 positionB,Point2 sizeB){
        bool xOverlap = positionA.x < positionB.x + sizeB.x &&
                        positionB.x < positionA.x + sizeA.x;

        bool yOverlap = positionA.y < positionB.y + sizeB.y &&
                        positionB.y < positionA.y + sizeA.y;

        return xOverlap && yOverlap;
    }

}