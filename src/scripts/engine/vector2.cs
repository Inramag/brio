namespace Engine;

public struct Vector2(float x, float y) {
    public float x = x;
    public float y = y;

    public static implicit operator System.Numerics.Vector2(Vector2 v) => new(v.x, v.y);

    public static Vector2 operator *(Vector2 l, float r) => new(l.x * r, l.y * r);
}