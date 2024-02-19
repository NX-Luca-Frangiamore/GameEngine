namespace Utils;
public record Point2(int x,int y){
    public static IEnumerable<Point2> GetPointsWithSameY(int y, int nVectors)
    {
        for (int i = 0; i < nVectors; i++)
        {
            yield return new Point2(i, y);
        }
    }
     public static IEnumerable<Point2> GetPointsWithSameX(int x, int nVectors)
    {
        for (int i = 0; i < nVectors; i++)
        {
            yield return new Point2(x, i);
        }
    }
    public Point2 Plus(Point2 v) => new(x + v.x, y + v.y);
    public Point2 Minus(Point2 v) => new(x - v.x, y - v.y);
    public bool IsBetweenA_B(Point2 A,Point2 B){
        bool isXBetween = (A.x <= x && x <= B.x) || (B.x <= x && x <= A.x);
        bool isYBetween = (A.y <= y && y <= B.y) || (B.y <= y && y <= y);
        return isXBetween && isYBetween;
    }
}