using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

namespace Domain.Tests;

[TestFixture]
public class GameObjectTests
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
    public void GameObject_GetDamage_ReducesHealth()
    {
        var health = new Health(100);
        var gameObject = new TestGameObject(
            mockInput.Object,
            new Position(0, 0),
            new Size(10, 10),
            health,
            new Speed(5),
            mockRepository.Object);
        
        gameObject.GetDamage(30);
        
        Assert.That(gameObject.HP.Value, Is.EqualTo(70));
    }
    
    [Test]
    public void GameObject_Die_RemovesFromRepository()
    {
        var gameObject = new TestGameObject(
            mockInput.Object,
            new Position(0, 0),
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            mockRepository.Object);
        
        gameObject.Die();
        
        mockRepository.Verify(r => r.Remove(gameObject), Times.Once);
        Assert.That(gameObject.IsDead, Is.True);
    }
    
    [Test]
    public void GameObject_MoveRight_WithinBounds_UpdatesPosition()
    {
        var startPos = new Position(10, 10);
        var gameObject = new TestGameObject(
            mockInput.Object,
            startPos,
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            mockRepository.Object);
        
        gameObject.TestMoveRight();
        
        Assert.That(gameObject.RectPosition.X, Is.EqualTo(15)); // 10 + 5
        Assert.That(gameObject.RectPosition.Y, Is.EqualTo(10));
    }
    
    [Test]
    public void GameObject_MoveRight_OutOfBounds_DoesNotMove()
    {
        var startPos = new Position(1190, 10);
        var gameObject = new TestGameObject(
            mockInput.Object,
            startPos,
            new Size(10, 10),
            new Health(100),
            new Speed(20),
            mockRepository.Object);

        gameObject.TestMoveRight();

        Assert.That(gameObject.RectPosition.X, Is.EqualTo(1190));
    }
    
    private class TestGameObject : GameObject
    {
        public TestGameObject(
            IGameInput input,
            Position position,
            Size size,
            Health health,
            Speed speed,
            IGameObjectRepository repository)
            : base(input, position, size, health, speed, repository)
        {
        }
        
        public void TestMoveLeft() => MoveLeft();
        public void TestMoveRight() => MoveRight();
        public void TestMoveUp() => MoveUp();
        public void TestMoveDown() => MoveDown();

        public override void Update() { }
    }
}