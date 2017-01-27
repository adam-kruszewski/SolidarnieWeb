
namespace Kruchy.Model.DataTypes.Walidacja
{
    public interface IWalidacjaListener
    {
        void Blad(string komunikat, string wlasciwosc);

        void Ostrzezenie(string komunikat, string wlasciwosc);
    }
}