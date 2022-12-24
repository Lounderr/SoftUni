namespace Program
{
    public interface IWriter
    {
        string WrittenMessageLog { get; }
        void Write(string msg);
    }
}