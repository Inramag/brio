namespace Engine;

public struct Rect(float x = 0, float y = 0, float width = 0, float height = 0) {
    public float x = x;
    public float y = y;
    public float width = width;
    public float height = height;

    public static implicit operator string(Rect r) => $"{r.x}, {r.y}, {r.width}, {r.height}";
    public static implicit operator Raylib_cs.Rectangle(Rect r) => new (r.x, r.y, r.width, r.height);
    public static implicit operator Rect(Raylib_cs.Rectangle r) => new (r.X, r.Y, r.Width, r.Height);
}