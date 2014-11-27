using System;
using System.ServiceModel;

namespace AutoupdaterHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(AutoupdaterService.AutoupdaterService)))
            {
                host.Open();
                Console.WriteLine("Service is running.");
                Console.ReadKey();
            }
        }
    }
}