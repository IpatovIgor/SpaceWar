/*using Raylib_cs;
namespace SpaceApplication;

public class Menu
{
    public void StartGame()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(1200, 900, "Space War");
        var backGround = Raylib.LoadTexture("menu.png");
        var startButton = new Button("start.png", 410, 250, 407, 162);
        var input = new KeyBoardInput();
        var gameController = new GameController(input);
        startButton.OnClick += () => { gameController.StartGame(); };

        var exitButton = new Button("exit.png", 420, 520, 372, 130);
        exitButton.OnClick += () => { Raylib.CloseWindow(); };

        var buttonController = new ButtonController();
        buttonController.Subscribe(startButton);
        buttonController.Subscribe(exitButton);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawTexture(backGround, -350, 0, Color.White);
            startButton.Print();
            exitButton.Print();
            Raylib.EndDrawing();
            
            buttonController.Update();
        }
    }
}*/