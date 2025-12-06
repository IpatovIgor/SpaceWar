using Domain;
using Raylib_cs;
using SpaceApplication;

namespace SpaceApplication;

public class Program
{
    public static void Main()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(1200, 900, "Space War");
        
        var gameLauncher = new GameLauncher();
        var menu = new MenuController(gameLauncher);
        
        menu.Run();
        
        Raylib.CloseWindow();
    }
}