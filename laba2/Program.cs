using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba2
{
    internal class Program
    {
        private static readonly object lockObj = new object();
        private static readonly object lockObj1 = new object();
        private static readonly object lockObj2 = new object();
        static void Main(string[] args)
        {
            Thread RedThread = new Thread(funcRed);
            RedThread.Priority = ThreadPriority.Highest;

            Thread GreenThread = new Thread(funcGreen);
            GreenThread.Priority = ThreadPriority.Normal;

            Thread BlueThread = new Thread(funcBlue);
            BlueThread.Priority = ThreadPriority.Lowest;

            RedThread.Start();
            GreenThread.Start();
            BlueThread.Start();

            Console.ReadLine();

            void funcRed()
            {
                for (int i = 0; i < 1000; i++) {
                    lock (lockObj1)
                    {
                        lock (lockObj2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Red thread");
                        }
                    }
                }
            }

            void funcGreen()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (lockObj1)
                    {
                        lock (lockObj2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Green thread");
                        }
                    }
                }
            }

            void funcBlue()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (lockObj1)
                    {
                        lock (lockObj2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Blue thread");
                        }
                    }
                }
            }
        }
    }
}
