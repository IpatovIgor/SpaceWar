using Presentation;
using Raylib_cs;

namespace SpaceApplication;

public class ButtonController
{
    private readonly List<Button> buttens = new();
    
    public void AddButton(Button button)
    {
        buttens.Add(button);
    }
    
    public void Update()
    {
        var mousePosition = Raylib.GetMousePosition();
        
        foreach (var clickable in buttens)
        {
            if (clickable.ContainsPoint(mousePosition) && 
                Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                clickable.OnClick?.Invoke();
                break;
            }
        }
    }
    
    public void Draw()
    {
        foreach (var clickable in buttens.OfType<Button>())
        {
            clickable.Draw();
        }
    }

    public void UnloadAllButtons()
    {
        foreach (var button in buttens)
        {
            button.Unload();
        }
    }
}