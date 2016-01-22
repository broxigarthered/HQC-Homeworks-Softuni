using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Performance_of_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            double n = 500;
            double b = double.MaxValue;

            // Performance of add -> +.
            stopwatch.Start();

            Math.Sin(n);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed {0}",stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }
}
