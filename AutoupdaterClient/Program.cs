using System;

namespace AutoupdaterClient
{
    class Program
    {
        static void Main()
        {
            try
            {
                var test = new TestApp();
                var updater = new Autoupdater(test);
                updater.Update();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            Console.WriteLine("Click any buttons..");
            Console.ReadKey();
        }

    }

    public class TestApp : IUpdatable
    {
        public string ApplicationId
        {
            get { return "BwinScriptUpdater"; }
        }

        public string ApplicationName
        {
            get { return ""; }
        }

        public string ApplicationPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public Version ApplicationVersion
        {
            get
            {
                return new Version(1,1);
            }
        }
    }

    public interface IUpdatable
    {
        string ApplicationId { get; }
        string ApplicationName { get; }
        string ApplicationPath { get; }
        Version ApplicationVersion { get; }
    }
}