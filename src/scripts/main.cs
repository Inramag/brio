using Engine;
using Engine.Components;

public class Brio {
    [Loader] static void Init() {
        Scene.Load(new Scene());
        
        var btn = new Image(Texture.Load(Assets.Get("panel.png")), "buttons") {
            rect = new Rect(0, 0, 400, 200),
            mode = Image.ImageMode.Slice9
        };
        btn.texture.border = 8;
        btn.texture.scale = 6;
    }
}