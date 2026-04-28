global using rl = Raylib_cs;

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Engine;
using Raylib_cs;

Directory.SetCurrentDirectory(AppContext.BaseDirectory);

//foreach (var dll in Directory.GetFiles(Path.Combine("..", "dll"), "*.dll"))
//    NativeLibrary.Load(dll);
NativeLibrary.Load("D:\\Projects\\c#\\brio\\build\\dll\\raylib.dll");

Scene.camera.background = new Engine.Color(80, 80, 80, 0);

Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);

Raylib.InitWindow(1280, 720, "Brio");
Scene.camera.resol = new Vector2Int(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

foreach (var m in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == null || !t.Namespace.StartsWith("Engine"))
                    .SelectMany(t => t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                    .Where(m => m.GetCustomAttribute<LoaderAttribute>() != null))
    m.Invoke(null, null);

while (!Raylib.WindowShouldClose()) {
    if (Raylib.IsWindowResized())
        Scene.camera.resol = new Vector2Int(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
            
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Scene.camera.background);
    Scene.Draw();
    Raylib.EndDrawing();
}

Raylib.CloseWindow();