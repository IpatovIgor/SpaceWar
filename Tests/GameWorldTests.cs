using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

[TestFixture]
public class GameWorldTests
{
    private GameWorld gameWorld;
    private Mock<IStatController> mockStatController;
    
    [SetUp]
    public void Setup()
    {
        mockStatController = new Mock<IStatController>();
        gameWorld = new GameWorld();
        gameWorld.statController = mockStatController.Object;
    }
    
    [Test]
    public void GameWorld_Add_AddsObjectToList()
    {
        var mockObj = new Mock<GameObject>(
            Mock.Of<IGameInput>(),
            new Position(0, 0),
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            Mock.Of<IGameObjectRepository>());
        
        gameWorld.Add(mockObj.Object);

        Assert.That(gameWorld.gameObjects, Contains.Item(mockObj.Object));
        Assert.That(gameWorld.gameObjects.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void GameWorld_CheckCollision_TwoCollidingObjects_ReturnsTrue()
    {
        var mockRepo = new Mock<IGameObjectRepository>();
    
        var obj1 = new Mock<GameObject>(
            Mock.Of<IGameInput>(),
            new Position(0, 0),
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            mockRepo.Object);
    
        var obj2 = new Mock<GameObject>(
            Mock.Of<IGameInput>(),
            new Position(5, 5),
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            mockRepo.Object);
        
        gameWorld.Add(obj1.Object);
        
        var result = gameWorld.CheckCollisionWithObject(obj2.Object);

        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GameWorld_UpdateAllObjects_WhenObjectDies_AddsScore()
    {
        var mockRepository = new Mock<IGameObjectRepository>();
        var asteroid = new Asteroid(
            new EnemyObjectInput(),
            new Position(100, 100),
            GameConfig.Asteroid.Size,
            new Health(1),
            new Speed(5),
            mockRepository.Object);
        
        gameWorld.Add(asteroid);
        
        asteroid.GetDamage(100);
        
        gameWorld.UpdateAllObjects();
        mockStatController.Verify(s => s.AddScore(GameConfig.Asteroid.Score), Times.Once);
    }
    
    [Test]
    public void GameWorld_UpdateStatForObj_PlayerShip_UpdatesPlayerHP()
    {
        var mockRepository = new Mock<IGameObjectRepository>();
        var playerShip = new PlayerShip(
            Mock.Of<IGameInput>(),
            new Position(0, 0),
            GameConfig.Player.Size,
            new Health(50),
            new Speed(5),
            mockRepository.Object,
            Direction.Up);
        
        gameWorld.UpdateStatForObj(playerShip);
        
        mockStatController.Verify(s => s.UpdatePlayerHP(50), Times.Once);
    }
}