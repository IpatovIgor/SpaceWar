using Domain;

namespace SpaceApplication;

public interface IButton: IRectangle
{
    public Action OnClick { get; set; }

    public void Print();
}