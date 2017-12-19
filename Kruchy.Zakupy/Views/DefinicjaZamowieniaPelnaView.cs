using System.Collections.Generic;

namespace Kruchy.Zakupy.Views
{
    public class DefinicjaZamowieniaPelnaView : DefinicjaZamowieniaView
    {
        public List<GrupaProduktowView> GrupyProduktow { get; set; }

        public DefinicjaZamowieniaPelnaView()
        {
            GrupyProduktow = new List<GrupaProduktowView>();
        }
    }
}
