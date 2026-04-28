namespace Engine;

public class Texture {
    internal rl.Texture2D _t2d;
    public Vector2Int size;
    public Color[] pixels;
    public Vector4Int border;

    private float _scale = 1;
    public float scale {
        get => _scale;
        set {
            border *= value;
            _scale = value;
            Apply();
        }
    }

    public Color this[int p] {
        get {
            if (p < 0 || p >= pixels.Length) 
                Console.Error($"Texture > get > Index {p} out of range (size: {pixels.Length})");
            return pixels[p];
        }
        set {
            if (p < 0 || p >= pixels.Length) 
                Console.Error($"Texture > set > Index {p} out of range (size: {pixels.Length})");
            pixels[p] = value;
        }
    }

    public bool IsEmpty => pixels.Length == 0 || _t2d.Id == 0;

    public void Apply() => Apply(Color.white);
    public void Apply(Color color, bool onlyfill = false) {
        var nsize = size * scale;

        unsafe {
            fixed(Color* ps = pixels) {
                var img = new rl.Image { Data = ps, Width = size.x, Height = size.y,
                    Mipmaps = 1, Format = rl.PixelFormat.UncompressedR8G8B8A8 };

                var wcopy = rl.Raylib.ImageCopy(img);

                rl.Raylib.ImageResizeNN(ref wcopy, nsize.x, nsize.y);
                
                if (rl.Raylib.IsTextureValid(_t2d)) rl.Raylib.UnloadTexture(_t2d);
                _t2d = rl.Raylib.LoadTextureFromImage(wcopy);

                rl.Raylib.UnloadImage(wcopy);
            }
        }
    }

    public static Texture Load(string path) {
        var image = rl.Raylib.LoadImage(path);
        rl.Raylib.ImageFormat(ref image, rl.PixelFormat.UncompressedR8G8B8A8);

        var w = image.Width;
        var h = image.Height;
        var pc = w * h;

        var pixels = new Color[pc];

        unsafe {
            Color* ptr = (Color*)image.Data;
            for (int i = 0; i < pc; i++)
                pixels[i] = ptr[i];
        }

        var txr = new Texture(pixels, new(w, h));
        txr.Apply();
        return txr;
    }

    public Texture() : this([], new(0, 0), 0) {}
    public Texture(Color[] pixels, Vector2Int size) : this(pixels, size, 0) {}
    public Texture(Color[] pixels, Vector2Int size, Vector4Int border) {
        this.size = size;
        this.pixels = pixels;
        this.border = border;
    }
}