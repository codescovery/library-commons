namespace Codescovery.Library.Commons.Entities.Directory
{
    public class FolderPath
    {
        internal string Value { get; private set; }
        public static implicit operator FolderPath(string value) => new FolderPath { Value = value };
        public static implicit operator string(FolderPath value) => value.Value;
    }
}