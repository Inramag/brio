using System;

namespace Engine.Components;

public class Image : Object {
    public enum ImageMode { Stretch, Slice9, Tile }

    public Texture texture = new();
    public Color color = Color.white;

    public ImageMode mode = ImageMode.Stretch;

    public Image() : base() {}
    public Image(string name) : base(name) {}
    public Image(string name, Object parent) : base(name, parent) {}
    public Image(string name, Object parent, Rect rect) : base(name, parent, rect) {}
    public Image(Color c) : this() => color = c;
    public Image(Texture t) : this() => texture = t;
    public Image(Texture t, string name) : this(name) => texture = t;
    public Image(Texture t, string name, Object parent) : this(name, parent) => texture = t;
    public Image(Texture t, string name, Object parent, Rect rect) : this(name, parent, rect) => texture = t;

    protected override void OnDraw() {
        var rect = wrect;
        if (!texture.IsEmpty) {
            var txr = texture;
            var size = (Vector2)txr.size * txr.scale;
            var brdr = txr.border;

            switch (mode) {
                case ImageMode.Stretch:
                    Core.DrawTexture(txr, rect);
                    return;
                case ImageMode.Slice9:
                    rl.Raylib.DrawTextureNPatch(
                        txr._t2d,
                        new rl.NPatchInfo {
                            Source = new Rect(0, 0, size.x, size.y),
                            Left = brdr.x, Right = brdr.z,
                            Top = brdr.y, Bottom = brdr.w,
                            Layout = rl.NPatchLayout.NinePatch
                        },
                        rect,
                        new Vector2(),
                        0,
                        color
                    );
                    return;
                default:
                    for (float x = rect.x; x < rect.x + rect.width; x += size.x)
                        for (float y = rect.y; y < rect.y + rect.height; y += size.y) {
                            float w = Math.Min(size.x, rect.x + rect.width - x);
                            float h = Math.Min(size.y, rect.y + rect.height - y);
                            rl.Raylib.DrawTexturePro(
                                txr._t2d,
                                new Rect(0, 0, w, h),
                                new Rect(x, y, w, h),
                                new Vector2(0, 0), 0, color);
                        }
                    return;
            }
        }
        else {
            rl.Raylib.DrawRectanglePro(
                rect,
                new Vector2(),
                0,
                color
            );
        }
    }
}