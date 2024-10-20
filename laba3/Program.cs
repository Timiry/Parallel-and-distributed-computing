using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number = 1000000;
            long allSum1 = 0;
            long allSum2 = 0;
            long allSum3 = 0;
            int process = Environment.ProcessorCount;
            long partSize = (long)(number / process);

            Limits[] arrLimits = new Limits[process];
            Thread[] arrThreads = new Thread[process];

            for (int i = 0; i < process; i++)
            {
                long partStart = i * partSize + 1;
                long partEnd = (i + 1) * partSize;
                if (i == process - 1) partEnd = number;

                Limits limits = new Limits(partStart, partEnd);
                arrLimits[i] = limits;

                Thread thread = new Thread(new ParameterizedThreadStart(Count));
                arrThreads[i] = thread;
                thread.Start(limits);
            }

            foreach (Thread thread in arrThreads) thread.Join();
            foreach (Limits limits in arrLimits) allSum1 += limits.sum;

            Console.WriteLine($"Сумма с разбиением на потоки: {allSum1}");

            for (long i = 0; i < number+1; i++) allSum2 += i;
            Console.WriteLine($"Сумма в одном потоке: {allSum2}");

            Parallel.For(0, number + 1, (i) => { Interlocked.Add(ref allSum3, i); });
            Console.WriteLine($"Сумма с помощью Parallel.For: {allSum3}");

            Console.ReadLine();
        }

        public static void Count(Object arg)
        {
            if (arg is Limits limits)
            {
                for (long i = limits.a; i <= limits.b; i++) limits.sum += i;
            }
        }

        public class Limits
        {
            public long a;
            public long b;
            public long sum = 0;
            public Limits(long a, long b) {
                this.a = a;
                this.b = b;
            }
        }
    }
}
