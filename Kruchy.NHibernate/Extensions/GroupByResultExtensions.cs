using System;

namespace Kruchy.NHibernate.Extensions
{
    public static class GroupByResultExtensions
    {
        public static T To<T>(this object[] value)
        {
            var result =
                (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);

            var properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, value.Length); i++)
            {
                properties[i].SetValue(result, value[i]);
            }

            return result;
        }
    }
}
