using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Domain;
using Kruchy.Zakupy.Repositories;
using Kruchy.Zakupy.Walidacja;

namespace Kruchy.Zakupy.Services.Impl
{
    class DefinicjeZamowieniaService : IDefinicjeZamowieniaService
    {
        private readonly IWalidacjaDefinicjiZamowienia walidacja;
        private readonly IDefinicjaZamowieniaRepository definicjaZamowieniaRepository;

        public DefinicjeZamowieniaService(
            IWalidacjaDefinicjiZamowienia walidacja,
            IDefinicjaZamowieniaRepository definicjaZamowieniaRepository)
        {
            this.walidacja = walidacja;
            this.definicjaZamowieniaRepository = definicjaZamowieniaRepository;
        }

        public int? Wstaw(
            WstawienieDefinicjiZamowieniaRequest request,
            IWalidacjaListener listenerWalidacji)
        {
            if (!walidacja.Waliduj(request, listenerWalidacji))
                return null;

            var definicja = new DefinicjaZamowienia
            {
                Nazwa = request.Nazwa,
                Plik = request.ZawartoscPliku,
                CzasKoncaZamawiania = request.DataKoncaZamawiania
            };
            var wstawiony = definicjaZamowieniaRepository.Save(definicja);
            return wstawiony.ID;
        }
    }
}