namespace Program
{
    public class GreetingWriter
    {
        public IWriter Writer { get; }

        public GreetingWriter(IWriter writer)
        {
            Writer = writer;
        }

        public void Write(string msg)
        {
            Writer.Write(msg);
        }
    }
}