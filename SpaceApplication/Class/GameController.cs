using System.Xml;
using Raylib_cs;
using Domain;
using SpaceApplication.Class;

namespace SpaceApplication;
using Raylib_cs;

public class GameController: IGameController
{
    private IGameInput gameInput;
    
    public GameController(IGameInput gameInput)
    {
        this.gameInput = gameInput;
    }
    
    public int StartGame()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(1200, 900, "Space War");
        
        var gameWorld = new GameWorld();
        new PlayerShip(gameInput, new Position(0, 650),
            new Size(85, 80), new Health(1000), new Speed(7), gameWorld, Direction.Up);
        var spawner = new Spawner(gameWorld);
        var backTexture = Raylib.LoadTexture("space.png");
        var viewMeneger = new ViewManager(gameWorld);
        new Base(new StopInput(), new Position(150, 700),
            new Size(841, 500), new Health(1000), new Speed(7), gameWorld, Direction.Up);
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(backTexture, 0, 0, Color.White);
            spawner.TrySpawn();
            gameWorld.UpdateAllObjects();
            viewMeneger.UpdateViewers();
            viewMeneger.PrintAll();
            Raylib.EndDrawing();
        }
        
        Raylib.UnloadTexture(backTexture);

        return 0;
    }
}