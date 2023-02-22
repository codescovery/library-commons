using System;
using System.Linq.Expressions;
using System.Text.Json;
using Codescovery.Library.Commons.Exceptions;
using Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrDefault(this object obj)
        {
            return obj == null || obj.Equals(default);
        }

        public static T As<T>(this object sourceObject, T defaultValue = default, bool throwExceptionOnError = false)
        {
            try
            {
                if (sourceObject.IsNullOrDefault())
                    return defaultValue;
                var parsedObject = (T) sourceObject;
                return parsedObject;
            }
            catch (Exception ex)
            {
                if (throwExceptionOnError)
                    throw new CastingException(sourceObject.GetType(), typeof(T), innerException: ex);
                return defaultValue;
            }
        }
        public static IFluentPropertySelectorService<T> And<T>(this T obj)
        {
            return new FluentPropertySelectorService<T>(obj);
        }
        public static IFluentPropertySelectorService<T> With<T>(this T obj) 
        {
            
            return new FluentPropertySelectorService<T>(obj);
        }
        public static IFluentPropertySelectorService<T> CloneWith<T>(this T obj) where T : new()
        {

            return new FluentPropertySelectorService<T>(obj.DeepClone());
        }

    }
}