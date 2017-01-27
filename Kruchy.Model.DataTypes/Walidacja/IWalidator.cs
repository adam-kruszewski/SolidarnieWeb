
namespace Kruchy.Model.DataTypes.Walidacja
{
    interface IWalidator<T>
    {
        bool Waliduj(T obiekt, IWalidacjaListener listener);
    }
}