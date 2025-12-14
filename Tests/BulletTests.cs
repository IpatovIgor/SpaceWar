using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

[TestFixture]
public class BulletTests
{
    [Test]
    public void Bullet_TakeDamage_DamagesTargetAndSelf()
    {
        var mockRepository = new Mock<IGameObjectRepository>();
        var bullet = new Bullet(
            new BulletInput(Direction.Up),
            new Position(100, 100),
            GameConfig.Bullet.Size,
            new Health(GameConfig.Bullet.Health),
            new Speed(GameConfig.Bullet.Speed),
            mockRepository.Object,
            Direction.Up);
        
        var mockTarget = new Mock<GameObject>(
            Mock.Of<IGameInput>(),
            new Position(0, 0),
            new Size(10, 10),
            new Health(100),
            new Speed(5),
            mockRepository.Object);
        
        bullet.TakeDamage(mockTarget.Object);
    }
    
    [Test]
    public void Bullet_Update_MoveUpEvent_MovesUp()
    {
        var mockRepository = new Mock<IGameObjectRepository>();
        var input = new BulletInput(Direction.Up);
        var bullet = new Bullet(
            input,
            new Position(100, 100),
            GameConfig.Bullet.Size,
            new Health(GameConfig.Bullet.Health),
            new Speed(10),
            mockRepository.Object,
            Direction.Up);
        
        bullet.Update();
        
        Assert.That(bullet.RectPosition.Y, Is.EqualTo(90)); // 100 - 10
    }
    
    [Test]
    public void Bullet_Update_WhenBelowMinY_Dies()
    {
        var mockRepository = new Mock<IGameObjectRepository>();
        var input = new BulletInput(Direction.Up);
        var bullet = new Bullet(
            input,
            new Position(100, 15),
            GameConfig.Bullet.Size,
            new Health(GameConfig.Bullet.Health),
            new Speed(10),
            mockRepository.Object,
            Direction.Up);
        
        bullet.Update();
        
        mockRepository.Verify(r => r.Remove(bullet), Times.Once);
        Assert.That(bullet.IsDead, Is.True);
    }
}