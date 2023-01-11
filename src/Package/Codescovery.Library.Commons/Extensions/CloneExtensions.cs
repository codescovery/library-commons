using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Codescovery.Library.Commons.Extensions
{
    public static class CloneExtensions
    {
        public const BindingFlags DefaultBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.
            Instance;
        public static T DeepClone<T>(this T source, BindingFlags bindingFlags = DefaultBindingFlags)
         where T : new()
        {
            if (source == null || source.Equals(default(T)))
                return default;
            var type = typeof(T);
            var result = Activator.CreateInstance<T>();

            do
                foreach (var field in type.GetFields(bindingFlags))
                    field.SetValue(result, field.GetValue(source));
            while ((type = type.BaseType) != typeof(object));

            return result;
        }
    }
}
