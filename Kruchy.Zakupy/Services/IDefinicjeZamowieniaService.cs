using System.Collections.Generic;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Views;

namespace Kruchy.Zakupy.Services
{
    public interface IDefinicjeZamowieniaService
    {
        DefinicjaZamowieniaPelnaView DajWgID(int definicjaID);

        int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji);

        IList<DefinicjaZamowieniaView> SzukajWszystkich();
    }
}