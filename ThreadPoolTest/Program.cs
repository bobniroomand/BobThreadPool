using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ThreadPoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch myWatch = new Stopwatch();
            myWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                PrintWithThread(i);
            }
            myWatch.Stop();
            Console.WriteLine("Elapsed Time without threadpooling: {0}", myWatch.ElapsedTicks);

            myWatch.Reset();

            BobThreadPool.ThreadPool tp = new BobThreadPool.ThreadPool();
            myWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                PrintWithThreadPool(tp, i);
            }
            myWatch.Stop();
            Console.WriteLine("Elapsed Time with threadpooling: {0}", myWatch.ElapsedTicks);
        }

        static void PrintWithThread(int i)
        {
            Thread t = new Thread(() => { Print(i); });
            t.Start();
        }

        static void PrintWithThreadPool(BobThreadPool.ThreadPool tp, int i)
        {
            Action<object> a = o => Print((int)o);
            Task t = new Task(a, i);
            tp.EnqueueTask(t);
        }

        static void Print(int i)
        {
            Console.WriteLine("this is task number {0}", i);
        }
    }
}
