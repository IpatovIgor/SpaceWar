using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

[TestFixture]
public class StatControllerTests
{
    [Test]
    public void StatController_AddScore_IncreasesScore()
    {
        var controller = new StatController();
        
        controller.AddScore(10);
        controller.AddScore(20);

        Assert.That(controller.AllScore.Value, Is.EqualTo(30));
    }
    
    [Test]
    public void StatController_AddScore_NegativeValue_ThrowsException()
    {
        var controller = new StatController();
        
        Assert.Throws<Exception>(() => controller.AddScore(-10));
    }
    
    [Test]
    public void StatController_UpdatePlayerHP_ZeroHealth_SetsGameOver()
    {
        var controller = new StatController();

        controller.UpdatePlayerHP(0);

        Assert.That(controller.GameIsOver, Is.True);
    }
    
    [Test]
    public void StatController_Reset_ResetsAllValues()
    {
        var controller = new StatController();
        controller.AddScore(100);
        controller.UpdatePlayerHP(50);
        controller.UpdateBaseHP(30);
        
        controller.Reset();

        Assert.That(controller.AllScore.Value, Is.EqualTo(0));
        Assert.That(controller.PlayerHP.Value, Is.EqualTo(100));
        Assert.That(controller.BaseHP.Value, Is.EqualTo(100));
        Assert.That(controller.GameIsOver, Is.False);
    }
}