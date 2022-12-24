using Moq;
using Program;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string consoleOutput;

            var myWriter = new Mock<IWriter>();

            myWriter.SetupSet(x => x.WrittenMessageLog).

            myWriter.Setup(x => x.Write(It.IsAny<string>()))
                .Callback((string str) =>
                {
                    consoleOutput = str;
                    myWriter.Object.WrittenMessageLog = str;
                });
        }
    }
}