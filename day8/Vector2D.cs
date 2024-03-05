public class Vector2D : IVector
{
    private int x, y;
    public Vector2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector2D operator +(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.x + v2.x, v1.y + v2.y);
    }
    public static int operator *(Vector2D v1, Vector2D v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }
    public static Vector3D operator ~(Vector2D v)
    {
        return new Vector3D(v.x, v.y, 0);
    }

    public override string ToString()
    {
        return $"({x},{y})";
    }

    public float Module()
    {
        return (float)Math.Round(Math.Sqrt(x * x + y * y),2);
    }
}