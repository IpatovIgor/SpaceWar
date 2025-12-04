using System.Xml;
using Raylib_cs;

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
        var gameObj = new List<GameObject>();
        var statController = new StatController();
        var updater = new Updater(gameObj, statController);
        var ship = new MyShip(gameInput, StaticData.DataForMyShip, gameObj, GameEvents.MoveUp);
        var spawner = new Spawner(gameObj);
        var backTexture = Raylib.LoadTexture("space.png");
        new Base(new StopInput(), StaticData.DataForBase, gameObj, GameEvents.MoveUp);
        var gameOverFlag = false;
        
        while (!Raylib.WindowShouldClose())
        {
            if (statController.GameIsOver)
            {
                gameOverFlag = true;
                break;
            }
            
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(backTexture, 0, 0, Color.White);
            statController.Print();
            
            updater.UpdateAllObjects(statController);
            spawner.TrySpawn(statController);
            Raylib.EndDrawing();
        }
        
        Raylib.UnloadTexture(backTexture);
        if (gameOverFlag is false)
        {
            Raylib.CloseWindow();
        }

        return statController.Score;
    }
}