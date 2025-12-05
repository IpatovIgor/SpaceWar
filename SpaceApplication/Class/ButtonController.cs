/*using Domain;
using Raylib_cs;
namespace SpaceApplication;

public class ButtonController
{
    private List<IButton> listOfButtons = new List<IButton>();

    public void Subscribe(IButton button)
    {
        listOfButtons.Add(button);
    }

    public void Update()
    {
        var mousePosition = Raylib.GetMousePosition();
        var mouseX = (int)mousePosition.X;
        var mouseY = (int)mousePosition.Y;
        foreach (var button in listOfButtons)
        {
            if (Collisions.PointInRectangle(new Point(mouseX, mouseY), button) 
                && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                button.OnClick();
                break;
            }
        }
    }
}*/