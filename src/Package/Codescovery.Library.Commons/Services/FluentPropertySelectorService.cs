using System;
using System.Linq.Expressions;
using Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object;

namespace Codescovery.Library.Commons.Services
{
    internal class FluentPropertySelectorService<T>:IFluentPropertySelectorService<T>
    {
        private readonly T _source;

        public FluentPropertySelectorService(T source)
        {
            _source = source;
        }

        public IFluentPropertySetterService<T, TMember> Property<TMember>(Expression<Func<T, TMember>> field)
        {
            return new FluentPropertySetterService<T, TMember>(_source, field);
        }
    }
}