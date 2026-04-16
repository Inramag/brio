namespace Engine;

public struct Camera(Vector2Int resol, Color background = new Color()) {
    public Vector2Int resol = resol;
    public Color background = background;
}