namespace Engine;

public struct Color(byte r = 255, byte g = 255, byte b = 255, byte a = 255) {
    public byte r = r;
    public byte g = g;
    public byte b = b;
    public byte a = a;

    public static readonly Color white = new(255);

    public static implicit operator rl.Color(Color c) => new(c.r, c.g, c.b, c.a);
    public static implicit operator Color(rl.Color c) => new(c.R, c.G, c.B, c.A);
}