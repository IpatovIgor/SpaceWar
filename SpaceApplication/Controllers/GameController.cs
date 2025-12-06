using Domain;

namespace SpaceApplication;
using Raylib_cs;

public class GameController: IGameController
{
    private GameWorld world;
    private IGameInput inputForPlayerShip;
    private ViewManager viewManager;
    private Spawner spawner;
    private IGameObjectRepository repository;
    private GameRenderer renderer;
    private PointMapper mapper;
    
    public GameController(
        GameWorld world,
        IGameInput input,
        ViewManager viewManager,
        Spawner spawner,
        IGameObjectRepository repository,
        GameRenderer renderer,
        PointMapper mapper
        )
    {
        this.mapper = mapper;
        this.renderer = renderer;
        this.world = world;
        inputForPlayerShip = input;
        this.viewManager = viewManager;
        this.spawner = spawner;
        this.repository = repository;
    }
    
    public int StartGame()
    {
        var playerShip = new PlayerShip(inputForPlayerShip, new Position(0, 650),
            new Size(85, 80), new Health(1000), new Speed(7), repository, Direction.Up);
        var backTexture = Raylib.LoadTexture("space.png");
        var @base = new Base(new StopInput(), new Position(150, 700),
            new Size(841, 500), new Health(1000), new Speed(7), repository, Direction.Up);

        while (!Raylib.WindowShouldClose())
        {
            var deltaTime = Raylib.GetFrameTime();
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(backTexture, 0, 0, Color.White);
            spawner.TrySpawn( deltaTime);
            world.UpdateAllObjects();
            viewManager.UpdateViewers();
            renderer.Render(viewManager.ViewsObjects);
            Raylib.EndDrawing();
        }
        
        Raylib.UnloadTexture(backTexture);

        return 0;
    }
}