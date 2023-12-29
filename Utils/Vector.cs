using System.Security.Cryptography.X509Certificates;

namespace Utils;
public record Vector2(int x,int y){
    public static IEnumerable<Vector2> GetVectorsByY(int y, int nVectors)
    {
        for (int i = 0; i < nVectors; i++)
        {
            yield return new Vector2(i, y);
        }
    }
     public static IEnumerable<Vector2> GetVectorsByX(int x, int nVectors)
    {
        for (int i = 0; i < nVectors; i++)
        {
            yield return new Vector2(x, i);
        }
    }
    public Vector2 Plus(Vector2 v) => new(x + v.x, y + v.y);
    public bool IsEqual(Vector2 v) => v.x == x && v.y == y;
}