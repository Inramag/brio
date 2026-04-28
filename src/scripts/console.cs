using System;

public static class Console {
    public static void Write(string s) => System.Console.Write(s);
    public static void WriteL(string s) => System.Console.WriteLine(s);
    public static void Error(string s) {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.Error.WriteLine($"[FATAL ERROR]: {s}");
        System.Console.ResetColor();
        Environment.Exit(1);
    }
}