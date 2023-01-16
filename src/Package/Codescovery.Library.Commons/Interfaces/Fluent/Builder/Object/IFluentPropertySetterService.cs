namespace Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object
{
    public interface IFluentPropertySetterService<out T, in TMember>
    {
        T Set(TMember value);
    }
}