using System.Diagnostics;

namespace Kodelabzz.Library.net
{
    public class MThreads
    {
        public static void Start()
        {
            ThreadClass threadClass = new ThreadClass();
            threadClass.MainRun();
            
            
        }
    }

    internal class ThreadClass
    {
        
        public void Run(object obj)
        {
            char c=(char)obj;
            for (int i = 0; i < 10000; i++)
            {
                Console.Write(c);
            }
        }
        public static bool finished = false;
        public void DoWork()
        {
            if(!finished)
            {
                Console.WriteLine("finished");
                finished = true;
            }
        }
        public void MainRun()
        {
            
            //Thread thread = new Thread(DoWork);
            //thread.Start();
            //DoWork();

            Thread thread1 = new Thread(() =>
            {
                DoWork();
            });
            thread1.Start();

            thread1.Join(); // wait for thread1 to complete

            DoWork();
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new(() =>
                {
                    IncrementCounter();
                });
                thread.Start();
                thread.Join();
            }
            stopwatch.Stop();
            long timetaken = stopwatch.ElapsedTicks;

            Console.WriteLine("counter final value: " + counter + " time taken " + timetaken);
        }

        private static int counter = 0;
        private static object syncObj = new object();
        private void IncrementCounter()
        {
            for (int i = 0; i < 10000; i++)
            {
                Interlocked.Increment(ref counter);
                //lock(syncObj)
                //{
                //    counter++;
                //}

            }
        }
    }
}
