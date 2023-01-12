namespace Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object
{
    public interface IFluentBuilderObjectValueSetter<out TObjectType>
    {
        TObjectType Set<TMemberType>(TMemberType value);
    }
}