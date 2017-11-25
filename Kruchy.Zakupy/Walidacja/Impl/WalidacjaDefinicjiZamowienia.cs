using System;
using System.IO;
using Kruchy.Model.DataTypes.Walidacja;
using Kruchy.Zakupy.Resources;
using Kruchy.Zakupy.Services;

namespace Kruchy.Zakupy.Walidacja.Impl
{
    class WalidacjaDefinicjiZamowienia : IWalidacjaDefinicjiZamowienia
    {
        public bool Waliduj(
            WstawienieDefinicjiZamowieniaRequest obiekt,
            IWalidacjaListener listener)
        {
            return new ZbiorRegulWalidacji()
                .DodajReguleBledu(
                    () => string.IsNullOrEmpty(obiekt.Nazwa),
                    Napisy.BrakNazwyZamowienia,
                    "Nazwa")

                .DodajReguleBledu(
                    () => string.IsNullOrEmpty(obiekt.NazwaPliku),
                    Napisy.BrakPlikuZamowienia,
                    "Plik")

                .DodajReguleBledu(
                    () => Rozszerzenie(obiekt.NazwaPliku) != ".xlsx",
                    Napisy.NiepoprawnyFormatPlikuZamowienia,
                    "Plik")

                .Wykonaj(listener);
        }

        private string Rozszerzenie(string nazwaPliku)
        {
            if (string.IsNullOrEmpty(nazwaPliku))
                return "";

            var info = new FileInfo(nazwaPliku);
            return info.Extension;
        }
    }
}
