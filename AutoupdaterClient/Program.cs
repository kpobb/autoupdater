using System;
namespace AutoupdaterClient
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var test = new TestApp();
                var updater = new Autoupdater(test);
                updater.ForceUpdate();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            Console.WriteLine("Click any buttons..");
            Console.ReadKey();
        }

        public class TestApp : IUpdatableApplication
        {
            public string Id
            {
                get { return "BwinScriptUpdater"; }
            }

            public string Name
            {
                get { return ""; }
            }

            public string Path
            {
                get { return AppDomain.CurrentDomain.BaseDirectory; }
            }

            public Version Version
            {
                get { return new Version(1, 1); }
            }
        }
    }

    public interface IUpdatableApplication
    {
        string Id { get; }
        string Name { get; }
        string Path { get; }
        Version Version { get; }
    }
}