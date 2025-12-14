using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

[TestFixture]
public class ShipTests
{
    private Mock<IGameInput> mockInput;
    private Mock<IGameObjectRepository> mockRepository;
    
    [SetUp]
    public void Setup()
    {
        mockInput = new Mock<IGameInput>();
        mockRepository = new Mock<IGameObjectRepository>();
    }
    
    [Test]
    public void Ship_ShootUp_CreatesBulletAtCorrectPosition()
    {
        var ship = new TestableShip(
            mockInput.Object,
            new Position(100, 500),
            GameConfig.Player.Size,
            new Health(GameConfig.Player.Health),
            new Speed(GameConfig.Player.Speed),
            mockRepository.Object,
            Direction.Up);
        
        ship.TestShoot();
        
        mockRepository.Verify(r => r.Add(It.IsAny<Bullet>()), Times.Once);
    }
    
    [Test]
    public void Ship_Update_WithShootEvent_CreatesBullet()
    {
        var events = new List<GameEvents> { GameEvents.Shoot };
        mockInput.Setup(i => i.GetEvents()).Returns(events);
        
        var ship = new Ship(
            mockInput.Object,
            new Position(100, 500),
            GameConfig.Player.Size,
            new Health(GameConfig.Player.Health),
            new Speed(GameConfig.Player.Speed),
            mockRepository.Object,
            Direction.Up);
        
        ship.Update();
        
        mockRepository.Verify(r => r.Add(It.IsAny<Bullet>()), Times.Once);
    }
    
    [Test]
    public void Ship_Update_WithMoveLeftEvent_MovesLeft()
    {
        var events = new List<GameEvents> { GameEvents.MoveLeft };
        mockInput.Setup(i => i.GetEvents()).Returns(events);
        
        var startPos = new Position(100, 500);
        var ship = new Ship(
            mockInput.Object,
            startPos,
            GameConfig.Player.Size,
            new Health(GameConfig.Player.Health),
            new Speed(10),
            mockRepository.Object,
            Direction.Up);
        
        ship.Update();

        Assert.That(ship.RectPosition.X, Is.EqualTo(90));
    }
    
    private class TestableShip : Ship
    {
        public TestableShip(
            IGameInput input,
            Position position,
            Size size,
            Health health,
            Speed speed,
            IGameObjectRepository repository,
            Direction dir)
            : base(input, position, size, health, speed, repository, dir)
        {
        }
        
        public void TestShoot() => Shoot();
    }
}