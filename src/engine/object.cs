using System.Collections.Generic;
using System.Linq;

namespace Engine;

public class Object {
    public readonly int id;
    public string name;
    public Rect rect;
    public int layer;

    public Object? parent { get; private set; }
    readonly List<Object> children = [];

    public void SetParent(Object? p) {
        if (p == this || p == parent) return;
        {
            Object? curr = p;
            while (curr != null) {
                if (curr == this) return;
                curr = curr.parent;
            }
        }
        if (parent == null) Scene.RemoveObject(this);
        else parent.children.Remove(this);

        if (p == null) Scene.AddObject(this);
        else p.children.Add(this);

        parent = p;
    }
    public void AddChild(Object obj) => obj.SetParent(this);
    public void Destroy() {
        foreach (var c in children) c.Destroy();
        if (parent is null) Scene.RemoveObject(this);
        else parent.children.Remove(this);

        if (id + 1 == _lid) _lid--;
        else _fid.Add(id);
    }

    public void Draw() {
        OnDraw();
        foreach(var c in children) c.Draw(); 
    }
    public void Update() {
        OnUpdate();
        foreach (var c in children) c.Update();
    }

    protected virtual void OnDraw() {}
    protected virtual void OnUpdate() {}

    static int _lid = 0;
    static readonly List<int> _fid = [];
    public Object() : this($"Object {_lid+1}") {}
    public Object(string name) : this(name, null) {}
    public Object(string name, Object? parent) : this(name, parent, new()) {}
    public Object(string name, Object? parent, Rect rect) : this(name, parent, rect, 0) {}
    public Object(string name, Object? parent, Rect rect, int layer) {
        if (_fid.Count == 0) id = _lid++;
        else {
            var _id = _fid.Min();
            _fid.Remove(_id);
            id = _id;
        }
        this.name = name;
        this.rect = rect;
        this.layer = layer;

        if (parent == null) Scene.AddObject(this);
        else parent.AddChild(this);
    }
}