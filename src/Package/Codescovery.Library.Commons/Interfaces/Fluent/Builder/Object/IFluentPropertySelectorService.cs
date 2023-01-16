using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object
{
    public interface IFluentPropertySelectorService<T>
    {
        IFluentPropertySetterService<T,TMember> Property<TMember>(Expression<Func<T, TMember>> field);
        //{
        //    return new FluentBuilder<T, TMember>(obj, field);
        //}

    }
}

