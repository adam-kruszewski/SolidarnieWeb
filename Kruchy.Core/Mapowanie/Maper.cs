using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kruchy.Core.Mapowanie
{
    public class Maper
    {
        public TWynik Mapuj<TWynik>(object zrodlo)
        {
            var propertiesyZrodlo = zrodlo.GetType().GetProperties();
            var propertiesyWynik = typeof(TWynik).GetProperties();

            var mapaPrzepisania = PrzygotujMapePrzepisania(propertiesyZrodlo, propertiesyWynik);

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var konstruktorWyniku =
            typeof(TWynik).GetConstructors(flags)
                .Where(constructor => constructor.GetParameters().Length == 0)
                .First();

            return PrzygotujObiektWynikowy<TWynik>(zrodlo, mapaPrzepisania, konstruktorWyniku);
        }

        private TWynik PrzygotujObiektWynikowy<TWynik>(
            object zrodlo,
            Dictionary<PropertyInfo, PropertyInfo> mapaPrzepisania,
            ConstructorInfo konstruktorWyniku)
        {
            var wynik = (TWynik)konstruktorWyniku.Invoke(new object[0]);
            foreach (var mapowanie in mapaPrzepisania)
            {
                mapowanie.Key.SetValue(wynik,
                    mapowanie.Value.GetValue(zrodlo));
            }

            return wynik;
        }

        private Dictionary<PropertyInfo, PropertyInfo> PrzygotujMapePrzepisania(
            PropertyInfo[] propertiesyZrodlo,
            PropertyInfo[] propertiesyWynik)
        {
            var mapaPrzepisania = new Dictionary<PropertyInfo, PropertyInfo>();

            foreach (var propWynik in propertiesyWynik)
            {
                var propZrodlo = SzukajPropertiesaZrodla(propertiesyZrodlo, propWynik);

                if (propZrodlo != null)
                    mapaPrzepisania[propWynik] = propZrodlo;
            }

            return mapaPrzepisania;
        }

        private PropertyInfo SzukajPropertiesaZrodla(
            PropertyInfo[] listaPropertiesow,
            PropertyInfo wzorzec)
        {
            return listaPropertiesow.Where(o => o.Name == wzorzec.Name)
                .SingleOrDefault(o => o.PropertyType == wzorzec.PropertyType);
        }
    }
}
