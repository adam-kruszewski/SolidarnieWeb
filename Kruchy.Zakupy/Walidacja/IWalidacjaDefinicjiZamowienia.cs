using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Services;

namespace Kruchy.Zakupy.Walidacja
{
    public interface IWalidacjaDefinicjiZamowienia
        : IWalidator<WstawienieDefinicjiZamowieniaRequest>
    {
    }
}
