using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Walidacja;

namespace Kruchy.Zakupy.Services.Impl
{
    class DefinicjeZamowieniaService : IDefinicjeZamowieniaService
    {
        private readonly IWalidacjaDefinicjiZamowienia walidacja;

        public DefinicjeZamowieniaService(
            IWalidacjaDefinicjiZamowienia walidacja)
        {
            this.walidacja = walidacja;
        }

        public int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji)
        {
            if (!walidacja.Waliduj(request, listenerWalidacji))
                return null;
            return 1;
        }
    }
}