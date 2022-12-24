namespace Program
{
    public class ConsoleWriter : IWriter
    {
        public string WrittenMessageLog { get; private set; }

        public void Write(string msg)
        {
            Console.WriteLine(msg);
            WrittenMessageLog = msg;
        }
    }
}