using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CalculatorInterface;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorClient = ServiceProxy.Create<ICalculatorService>(new Uri("fabric:/CalculatorApplication/CalculatorService"));
            var result = calculatorClient.Add(1, 2).Result;

            Console.WriteLine(result);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
