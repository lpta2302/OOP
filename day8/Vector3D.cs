public class Vector3D : IVector
{
    private int x, y, z;
    public Vector3D(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static Vector3D operator +(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }
    public static int operator *(Vector3D v1, Vector3D v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }
    public static Vector2D operator ~(Vector3D v)
    {
        return new Vector2D(v.x, v.y);
    }

    public override string ToString()
    {
        return $"({x},{y},{z})";
    }

    public float Module()
    {
        return (float)Math.Round(Math.Sqrt(x * x + y * y + z * z), 2);
    }
}