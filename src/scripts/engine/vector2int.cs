using System.Numerics;

namespace Engine;

public struct Vector2Int(int x = 0, int y = 0) {
    public int x = x;
    public int y = y;

    public static implicit operator Vector2(Vector2Int v) => new(v.x, v.y);
    public static Vector2Int operator *(Vector2Int l, float r) => new((int)(l.x * r), (int)(l.y * r));
}