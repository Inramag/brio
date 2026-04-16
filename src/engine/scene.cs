using System.Collections.Generic;
using System.Linq;

namespace Engine;

public class Scene {
    public readonly int id;
    public Camera camera;
    readonly List<Object> objects = [];

    static int _lid = 0;
    static readonly List<int> _fid = [];
    static Scene _curr;
    static readonly List<Scene> _scenes = [];

    public Scene() : this(new Camera(new Vector2Int(1920, 1080), new Color(80, 80, 80))) {}
    public Scene(Camera _camera) {
        if (_fid.Count == 0) id = _lid++;
        else {
            var _id = _fid.Min();
            _fid.Remove(_id);
            id = _id;
        }
        camera = _camera;
        _scenes.Add(this);
    }
    public static void Load(Scene scene) => _curr = scene;

    public static void Unload(Scene scene) {
        if (scene == _curr) return;
        if (scene.id + 1 == _lid) _lid--;
        else _fid.Add(scene.id);
        
        _scenes.Remove(scene);
    }

    public static void AddObject(Object obj) {
        if (!_curr.objects.Contains(obj)) _curr.objects.Add(obj);
    }
    public static void RemoveObject(Object obj) {
        _curr.objects.Remove(obj);
    }

    public static void Draw() {
        foreach (var obj in _curr.objects) obj.Draw();
    }
    public static void Update() {
        foreach (var obj in _curr.objects) obj.Update();
    }

    public static bool operator ==(Scene l, Scene r) => l.id == r.id;
    public static bool operator !=(Scene l, Scene r) => l.id != r.id;

    public override bool Equals(object obj) => obj is Scene s && s.id == id;
    public override int GetHashCode() => id.GetHashCode();
}