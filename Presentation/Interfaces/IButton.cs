using Domain;

namespace Presentation;

public interface IButton: IRectangle
{
    public Action OnClick { get; set; }

    public void Print();
}