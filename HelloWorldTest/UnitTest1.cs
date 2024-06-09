using HelloWorld;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace HelloWorldTest;

public class Tests
{
    private Hello _helloWorld { get; set; }
    private class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
    
    
    
    [SetUp]
    public void Setup()
    {
        _helloWorld = new Hello();
    }

    [Test]
    public void PrintHelloWorldTest()
    {

        var currentConsoleOut = Console.Out;
        string text = string.Format("HelloWorld!{0}", Environment.NewLine);
        
        using (var consoleOutput = new ConsoleOutput())
        {
            _helloWorld.PrintHelloWorld();
            Assert.That(text, Is.EqualTo(consoleOutput.GetOuput()));
        }
        Assert.That(currentConsoleOut, Is.EqualTo(Console.Out));
    }
}