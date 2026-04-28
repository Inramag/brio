using Engine;
using Engine.Components;

public static class Core {
    public static void DrawTexture(Texture texture) => DrawTexture(texture, new(0, 0, texture.size.x, texture.size.y));
    public static void DrawTexture(Texture texture, Rect rect) {
        var s = texture.size;
        rl.Raylib.DrawTexturePro(
            texture._t2d,
            new Rect(0, 0, s.x, s.y),
            rect,
            new Vector2(0, 0), 0,
            Color.white
        );
    }
}