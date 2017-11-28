using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services
{
    public interface IDefinicjeZamowieniaService
    {
        int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji);

        IList<DefinicjaZamowieniaView> SzukajWszystkich();
    }
}