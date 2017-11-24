using Kruchy.Model.DataTypes.Walidacja;

namespace Kruchy.Zakupy.Services
{
    public interface IDefinicjeZamowieniaService
    {
        int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji);
    }
}