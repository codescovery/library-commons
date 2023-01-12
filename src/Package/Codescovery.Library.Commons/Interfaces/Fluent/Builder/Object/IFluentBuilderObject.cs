using System.Threading.Tasks;

namespace Codescovery.Library.Commons.Interfaces.Fluent.Builder.Object
{
    public interface IFluentBuilderObject<out T>
    {
        T Source { get; }
        
    }
}

