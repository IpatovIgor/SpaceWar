// Application/Controllers/MenuController.cs
using Raylib_cs;
using Presentation;

namespace SpaceApplication;

public class MenuController
{
    private readonly GameLauncher gameLauncher;
    private readonly ButtonController buttonController;
    private readonly Background background;
    private bool shouldStartGame = false;
    
    public MenuController(GameLauncher gameLauncher)
    {
        this.gameLauncher = gameLauncher;
        buttonController = new ButtonController();
        background = new Background("menu.png");
        
        InitializeButtons();
    }
    
    private void InitializeButtons()
    {
        var startButton = new Button("start.png", 410, 250, 407, 162);
        startButton.OnClick = () => shouldStartGame = true;
        
        var exitButton = new Button("exit.png", 420, 520, 372, 130);
        exitButton.OnClick = () => gameShouldStop = true;
        
        buttonController.AddButton(startButton);
        buttonController.AddButton(exitButton);
    }
    
    private bool gameShouldStop;
    
    public void Run()
    {
        while (!gameShouldStop)
        {
            if (Raylib.WindowShouldClose())
                gameShouldStop = true;
            Update();
            Draw();
            if (!shouldStartGame) continue;
            gameLauncher.LaunchGame();
            shouldStartGame = false;
            score = gameLauncher.AllScore;
        }
    }
    
    private void Update()
    {
        buttonController.Update();
    }

    private int score;
    
    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        
        background.Draw();
        buttonController.Draw();
        Raylib.DrawText($"The Best Score: {score}", 330, 150, 60, Color.Gold);
        
        Raylib.EndDrawing();
    }
}