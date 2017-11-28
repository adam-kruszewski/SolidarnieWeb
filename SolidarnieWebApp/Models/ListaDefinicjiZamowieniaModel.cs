using System.Collections.Generic;
using System.Linq;
using Kruchy.Zakupy.Views;

namespace SolidarnieWebApp.Models
{
    public class ListaDefinicjiZamowieniaModel
    {
        public IEnumerable<DefinicjaZamowieniaRowModel> Definicje { get; set; }

        public ListaDefinicjiZamowieniaModel(IEnumerable<DefinicjaZamowieniaView> definicje)
        {
            Definicje = definicje.Select(o => DajRowModel(o));
        }

        private DefinicjaZamowieniaRowModel DajRowModel(DefinicjaZamowieniaView o)
        {
            return new DefinicjaZamowieniaRowModel
            {
                ID = o.ID,
                Nazwa = o.Nazwa,
                CzasKoncaZamawiania = o.CzasKoncaZamawiania
            };
        }
    }
}