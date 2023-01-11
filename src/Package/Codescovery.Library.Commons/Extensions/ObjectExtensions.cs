namespace Codescovery.Library.Commons.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrDefault(this object obj)
        {
            return obj == null || obj.Equals(default);
        }
    }
}