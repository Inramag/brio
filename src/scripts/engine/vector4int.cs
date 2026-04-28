using Engine;

public struct Vector4Int(int x, int y, int z, int w) {
    public int x = x;
    public int y = y;
    public int z = z;
    public int w = w;

    public static implicit operator Vector4Int(int n) => new(n, n, n, n);
    public static Vector4Int operator *(Vector4Int l, float r) => new((int)(l.x * r), (int)(l.y * r), (int)(l.z * r), (int)(l.w * r));
}