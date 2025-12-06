// Application/Controllers/MenuController.cs
using Raylib_cs;
using Presentation;

namespace SpaceApplication;

public class MenuController
{
    private readonly GameLauncher _gameLauncher;
    private readonly ButtonController _buttonController;
    private readonly Background _background;
    private bool _shouldStartGame = false;
    
    public MenuController(GameLauncher gameLauncher)
    {
        _gameLauncher = gameLauncher;
        _buttonController = new ButtonController();
        _background = new Background("menu.png");
        
        InitializeButtons();
    }
    
    private void InitializeButtons()
    {
        var startButton = new Button("start.png", 410, 250, 407, 162);
        startButton.OnClick = () => _shouldStartGame = true;
        
        var exitButton = new Button("exit.png", 420, 520, 372, 130);
        exitButton.OnClick = () => Raylib.CloseWindow();
        
        _buttonController.AddButton(startButton);
        _buttonController.AddButton(exitButton);
    }
    
    public void Run()
    {
        while (!Raylib.WindowShouldClose() && !_shouldStartGame)
        {
            Update();
            Draw();
        }
        
        if (_shouldStartGame)
        {
            _gameLauncher.LaunchGame();
        }
    }
    
    private void Update()
    {
        _buttonController.Update();
    }
    
    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        
        _background.Draw();
        _buttonController.Draw();
        
        Raylib.EndDrawing();
    }
}