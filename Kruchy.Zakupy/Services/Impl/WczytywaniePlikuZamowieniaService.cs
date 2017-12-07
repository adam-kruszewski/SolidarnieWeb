using System;
using System.IO;
using System.Linq;
using Kruchy.Zakupy.BusinessObject;
using OfficeOpenXml;

namespace Kruchy.Zakupy.Services.Impl
{
    class WczytywaniePlikuZamowieniaService : IWczytywaniePlikuZamowieniaService
    {
        private const int KolumnaNazwaPozycji = 1;
        private const int KolumnaCena = 3;
        private const int KolumnaIlosc = 4;

        public Zamowienie Wczytaj(byte[] zawartoscPliku)
        {
            using (var tymczasowy = new TymczasowyPlik(".xslx"))
            {
                File.WriteAllBytes(tymczasowy.NazwaPliku, zawartoscPliku);
                return Wczytaj(tymczasowy.NazwaPliku);
            }
        }

        private Zamowienie Wczytaj(string sciezka)
        {
            var wynik = new Zamowienie();
            wynik.Nazwa = DajNazweZamowienia(sciezka);
            var wynikOtwarcia = DajSheetZamowienia(sciezka);
            var sheetZamowienia = wynikOtwarcia.Worksheet;

            int aktIndexWiersza = 4;
            GrupaProduktow aktGrupa = null;
            do
            {
                if (WierszPoczatkuGrupy(sheetZamowienia, aktIndexWiersza))
                    aktGrupa = DodajNowaGrupeProduktow(
                        wynik,
                        sheetZamowienia,
                        aktIndexWiersza);
                else
                    DodajNowaPozycje(
                        aktGrupa,
                        sheetZamowienia,
                        aktIndexWiersza);
                aktIndexWiersza++;
            } while (PierwszyWierszZaZamowieniem(sheetZamowienia, aktIndexWiersza));

            wynikOtwarcia.Package.Dispose();
            return wynik;
        }

        private string DajNazweZamowienia(string sciezka)
        {
            var fileInfo = new FileInfo(sciezka);
            return fileInfo.Name;
        }

        private Produkt DodajNowaPozycje(
            GrupaProduktow aktGrupa,
            ExcelWorksheet sheetZamowienia,
            int aktIndexWiersza)
        {
            var pozycja = new Produkt();
            pozycja.Nazwa = sheetZamowienia.Cell(aktIndexWiersza, KolumnaNazwaPozycji).Value;
            pozycja.NumerPozycjiWExcelu = aktIndexWiersza;
            var wartoscIlosci = sheetZamowienia.Cell(aktIndexWiersza, KolumnaIlosc).Value;

            if (string.IsNullOrEmpty(wartoscIlosci))
                pozycja.Ilosc = 0;
            else
                pozycja.Ilosc = int.Parse(wartoscIlosci);
            pozycja.Cena = sheetZamowienia.Cell(aktIndexWiersza, KolumnaCena).Value;

            aktGrupa.Pozycje.Add(pozycja);
            return pozycja;
        }

        private GrupaProduktow DodajNowaGrupeProduktow(
            Zamowienie wynik,
            ExcelWorksheet sheetZamowienia,
            int aktIndexWiersza)
        {
            var aktGrupa = new GrupaProduktow();
            aktGrupa.Nazwa = sheetZamowienia.Cell(aktIndexWiersza, KolumnaNazwaPozycji).Value;
            wynik.GrupyProduktow.Add(aktGrupa);
            return aktGrupa;
        }

        private bool WierszPoczatkuGrupy(ExcelWorksheet sheet, int aktIndexWiersza)
        {
            var komorka = sheet.Cell(aktIndexWiersza, KolumnaCena);
            var wartosc = komorka.Value;

            if (sheet.Cell(aktIndexWiersza, KolumnaNazwaPozycji).Value == "--")
                return false;
            if (string.IsNullOrEmpty(wartosc))
                return true;

            if (wartosc.All(o => char.IsDigit(o) || o == '.' || o == ','))
                return false;

            return true;

        }

        private bool PierwszyWierszZaZamowieniem(
            ExcelWorksheet sheetZamowienia,
            int aktIndexWiersza)
        {
            return !string.IsNullOrEmpty(
                sheetZamowienia.Cell(aktIndexWiersza, KolumnaNazwaPozycji).Value);
        }

        private WynikOtwarcia DajSheetZamowienia(string sciezka)
        {
            var fileInfo = new FileInfo(sciezka);
            ExcelPackage package = new ExcelPackage(fileInfo);
            var workbook = package.Workbook;
            var wynik = new WynikOtwarcia()
            {
                Worksheet = workbook.Worksheets[1],
                Package = package
            };
            return wynik;
        }

        private class WynikOtwarcia
        {
            public ExcelWorksheet Worksheet { get; set; }
            public ExcelPackage Package { get; set; }
        }

        private class TymczasowyPlik : IDisposable
        {
            public string NazwaPliku { get; private set; }

            public TymczasowyPlik(string rozszerzenie)
            {
                NazwaPliku = Path.Combine(
                    Path.GetTempPath(),
                    Guid.NewGuid().ToString() + rozszerzenie);
            }

            public void Dispose()
            {
                if (File.Exists(NazwaPliku))
                    File.Delete(NazwaPliku);
            }
        }
    }
}