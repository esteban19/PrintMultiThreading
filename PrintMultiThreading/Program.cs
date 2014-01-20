using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintMultiThreading
{
    public class Printer
    {
        private object threadLock = new object();

        public int Sum(int toAdd, int index)
        {
            return toAdd + index;
        }

        public void PrintNumbers()
        {
            lock (threadLock)
            {
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                Console.Write("Numbers: ");
                int summation = 0;
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    summation = Sum(summation, i);
                    Console.Write("{0}, ", summation);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer();

            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }
        }
    }
}
