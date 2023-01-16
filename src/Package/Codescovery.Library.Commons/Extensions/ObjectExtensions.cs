using System;
using System.Linq.Expressions;
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

        //public static IFluentPropertySetterService<> With<T, TMember>(this T obj, Expression<Func<T, TMember>> field)
        //{
        //    return new FluentBuilder<T, TMember>(obj, field);
        //}
        public static IFluentPropertySelectorService<T> With<T>(this T obj)
        {
            return new FluentPropertySelectorService<T>(obj);
        }

    }
}