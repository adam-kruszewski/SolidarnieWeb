
namespace Kruchy.Model.DataTypes.Walidacja
{
    public interface IWalidator<T>
    {
        bool Waliduj(T obiekt, IWalidacjaListener listener);
    }
}