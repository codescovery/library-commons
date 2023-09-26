using System;
using System.Reflection;

namespace Codescovery.Library.Commons.Extensions
{
    public static class CloneExtensions
    {
        public const BindingFlags DefaultBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.
            Instance;
        public static T? DeepClone<T>(this T? source, BindingFlags bindingFlags = DefaultBindingFlags)
         where T : new()
        {
            if (source == null || source.Equals(default(T)))
                return default;
            var type = typeof(T);
            var result = Activator.CreateInstance<T>();

            do
                if (type != null)
                    CloneNew(source, bindingFlags, type, result);
            while (type != null && (type = type.BaseType) != typeof(object));

            return result;
        }
        public static void DeepClone<T>(this T? source,T? to, BindingFlags bindingFlags = DefaultBindingFlags)
            where T : class
        {
            if (source == null || source.Equals(default(T)))
                return;
            if(to.IsNullOrDefault())
                throw new ArgumentNullException($"You must initialize the {nameof(to)} parameter before cloning");
            var type = typeof(T);
            do
                if (type != null)
                    Clone(source, bindingFlags, type, to);
            while (type != null && (type = type.BaseType) != typeof(object));
        }

        public static void CloneNew<T>(this T source, BindingFlags bindingFlags, Type type, T result) where T : new()
        {
            foreach (var field in type.GetFields(bindingFlags))
                field.SetValue(result, field.GetValue(source));
        }
        public static void Clone<T>(this T source, BindingFlags bindingFlags, Type type, T result) where T : class?
        {
            foreach (var field in type.GetFields(bindingFlags))
                field.SetValue(result, field.GetValue(source));
        }
    }
}
