namespace Engine;

public struct Anchor(float minX = 0, float minY = 0, float maxX = 0, float maxY = 0) {
    public float minx = minX;
    public float miny = minY;
    public float maxx = maxX;
    public float maxy = maxY;

    public static Anchor TopLeft      => new(0,    0,    0,    0);
    public static Anchor TopCenter    => new(0.5f, 0,    0.5f, 0);
    public static Anchor TopRight     => new(1,    0,    1,    0);
    public static Anchor MiddleLeft   => new(0,    0.5f, 0,    0.5f);
    public static Anchor Center       => new(0.5f, 0.5f, 0.5f, 0.5f);
    public static Anchor MiddleRight  => new(1,    0.5f, 1,    0.5f);
    public static Anchor BottomLeft   => new(0,    1,    0,    1);
    public static Anchor BottomCenter => new(0.5f, 1,    0.5f, 1);
    public static Anchor BottomRight  => new(1,    1,    1,    1);

    public static Anchor StretchHorizontal => new(0,    0.5f, 1,    0.5f);
    public static Anchor StretchVertical   => new(0.5f, 0,    0.5f, 1);
    public static Anchor StretchFull       => new(0,    0,    1,    1);

    
    public readonly bool IsHStretch => minx != maxx;
    public readonly bool IsVStretch => miny != maxy;
    public readonly bool IsStretch => minx != maxx || miny != maxy;

    public static bool operator ==(Anchor l, Anchor r) => l.minx == r.minx && l.maxx == r.maxx && l.miny == r.miny && l.maxy == r.maxy;
    public static bool operator !=(Anchor l, Anchor r) => !(l == r);
}