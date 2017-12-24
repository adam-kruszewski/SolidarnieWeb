using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kruchy.Core.Mapowanie
{
    public class Maper
    {
        public TWynik Mapuj<TWynik>(object zrodlo)
        {
            return (TWynik)Mapuj(zrodlo, typeof(TWynik));
        }

        public object Mapuj(object zrodlo, Type typWyniku)
        {
            var propertiesyZrodlo = zrodlo.GetType().GetProperties();
            var propertiesyWynik = typWyniku.GetProperties();

            var mapaPrzepisania = PrzygotujMapePrzepisania(propertiesyZrodlo, propertiesyWynik);

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var konstruktorWyniku =
            typWyniku.GetConstructors(flags)
                .Where(constructor => constructor.GetParameters().Length == 0)
                .First();

            return PrzygotujObiektWynikowy(zrodlo, mapaPrzepisania, konstruktorWyniku);

        }

        private object PrzygotujObiektWynikowy(
            object zrodlo,
            Dictionary<PropertyInfo, PropertyInfo> mapaPrzepisania,
            ConstructorInfo konstruktorWyniku)
        {
            var wynik = konstruktorWyniku.Invoke(new object[0]);
            foreach (var mapowanie in mapaPrzepisania)
            {
                if (!JestKolekcja(mapowanie))
                    mapowanie.Key.SetValue(wynik, mapowanie.Value.GetValue(zrodlo));
                else
                    DodajElementyKolekcji(mapowanie, zrodlo, wynik);
            }

            return wynik;
        }

        private bool JestKolekcja(KeyValuePair<PropertyInfo, PropertyInfo> mapowanie)
        {
            var typKolekcja = typeof(IList);
            var typWlasciwosci = mapowanie.Key.PropertyType;

            return typKolekcja.IsAssignableFrom(typWlasciwosci);
        }

        private void DodajElementyKolekcji<TWynik>(
            KeyValuePair<PropertyInfo, PropertyInfo> mapowanie,
            object zrodlo,
            TWynik wynik)
        {
            var wartoscZrodla = mapowanie.Value.GetValue(zrodlo) as IEnumerable;

            var wartoscWyniku = mapowanie.Key.GetValue(wynik) as IList;

            foreach (var obiektListyZrodlo in wartoscZrodla)
                wartoscWyniku.Add(
                    Mapuj(
                        obiektListyZrodlo,
                        OkreslTypElementuKolekcji(mapowanie.Key.PropertyType)));
        }

        private Type OkreslTypElementuKolekcji(Type propertyType)
        {
            if (propertyType.GenericTypeArguments.Count() == 1)
                return propertyType.GenericTypeArguments.Single();
            else
                return typeof(object);
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
            return listaPropertiesow.SingleOrDefault(o => o.Name == wzorzec.Name);
        }
    }
}
