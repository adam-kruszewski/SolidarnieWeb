namespace Kruchy.Core.Mapowanie
{
    public static class MaperExtensions
    {
        public static T Mapuj<T>(this object zrodlo)
        {
            return new Maper().Mapuj<T>(zrodlo);
        }
    }
}
