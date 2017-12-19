using System.Collections.Generic;

namespace Kruchy.Zakupy.Views
{
    public class GrupaProduktowView
    {
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public int? Limit { get; set; }

        public List<ProduktView> Produkty { get; set; }

        public GrupaProduktowView()
        {
            Produkty = new List<ProduktView>();
        }
    }
}
