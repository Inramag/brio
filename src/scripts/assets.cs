using System.IO;

public static class Assets {
    public static readonly string assets = Path.Combine("..", "data", "assets");

    public static string Get(string asset) => Path.GetFullPath(Path.Combine(assets, asset));
}