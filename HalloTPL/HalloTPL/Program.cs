using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo TPL");

            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle, Zähle);
            //Parallel.For(0, 1000000, i => Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]: {i}"));

            Task t1 = new Task(() =>
            {
                Console.WriteLine("T1 gestarted");
                Thread.Sleep(600);
                Console.WriteLine("T1 fertig");
                //throw new Exception();

            });

            t1.ContinueWith(tt => Console.WriteLine("T1 Continue"));
            t1.ContinueWith(tt => Console.WriteLine("T1 OK"), TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.ContinueWith(tt => Console.WriteLine("T1 ERROR"), TaskContinuationOptions.OnlyOnFaulted);


            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 berechnung gestarted...");
                Thread.Sleep(800);
                Console.WriteLine("T2 fertig");
                return 8734784387;
            });

            var tc = t2.ContinueWith(tt =>
            {
                return tt.Result * 2;
            });

            t1.Start();
            t2.Start();

            Console.WriteLine(tc.Result);

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]: {i}");
            }
        }
    }
}
