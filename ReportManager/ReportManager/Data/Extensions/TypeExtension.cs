using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ReportManager.Data.Extensions
{
    internal static class TypeExtension
    {
        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof((string, string)));
        }

        public static IEnumerable<KeyValuePair<string, object>> PropertiesToDict(this IEnumerable<object> objects)
        {
            foreach (var obj in objects)
                foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    if (IsSimple(property.PropertyType))
                        yield return new KeyValuePair<string, object>(property.Name, property.GetValue(obj) ?? "Нет значения");
        }

        public static IEnumerable<(string Name, object Value)> PropertiesToTuple<T>(this T obj)
        {
            foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                if (IsSimple(property.PropertyType))
                    yield return (property.Name, property.GetValue(obj) ?? "Нет значения");
        }

        public static void ForEach<T>(this IEnumerable<T> objects, Action<T> processFunc)
        {
            foreach (var o in objects)
                processFunc(o);
        }

        public static IEnumerable<T> AdaptWithSameProperties<T, T1>(this IEnumerable<T1> source) 
            where T: class, new()
            where T1 : class
        {
            foreach (var row in source)
            {
                var result = new T();
                row.PropertiesToTuple()
                   .ForEach(t =>
                            {
                                typeof(T)
                                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .FirstOrDefault(p => p.Name.ToLower() == t.Name.ToLower())
                                ?.SetValue(result, t.Value);
                            });
                yield return result;
            }
        }

        public static IEnumerable<T> SapAdaptWithSameProperties<T>(this IEnumerable<(string,string)> source)
            where T : class, new()
        {
            var result = new T();
            source.PropertiesToTuple()
                  .ForEach(t =>
                  {
                      typeof(T)
                          .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                          .FirstOrDefault(p => p.Name.ToLower() == t.Name.ToLower())
                          ?.SetValue(result, t.Value);
                  });
            yield return result;
        }
    }
}
