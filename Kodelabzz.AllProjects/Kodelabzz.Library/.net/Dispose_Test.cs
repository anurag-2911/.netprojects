using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodelabzz.Library.net
{
    public class Dispose_Test
    {
        public static long FinalizedObjects = 0;
        public static long TotalTime = 0;

        public static void Run()
        {
            Console.WriteLine("running with dispose pattern in place");
            RunWithDispose();

            FinalizedObjects = 0;
            TotalTime = 0;
            Console.WriteLine("running without dispose");
            RunWithoutDispose();

            
          
        }

        private static void RunWithDispose()
        {
            for (int i = 0; i < 500000; i++)
            {
                using (var obj = new WithDispose())
                {
                    obj.DoWork();
                }
            }
            long averageLifeTime = 1 * TotalTime / FinalizedObjects;
            Console.WriteLine("number of disposed objects : {0}", FinalizedObjects);
            Console.WriteLine("average resource lifetime : {0}", averageLifeTime);
        }

        private static void RunWithoutDispose()
        {
            for (int i = 0; i < 500000; i++)
            {
                var obj = new WithoutDispose();
                obj.DoWork();
            }
            long averageLifeTime = 1 * TotalTime / FinalizedObjects;
            Console.WriteLine("number of disposed objects : {0}", FinalizedObjects);
            Console.WriteLine("average resource lifetime : {0}", averageLifeTime);
        }
    }

    public class WithDispose:IDisposable
    {
        private Stopwatch stopwatch;
        private bool isDisposed;

        public WithDispose()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        public void DoWork()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    _ = i * j;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!isDisposed)
            {
                stopwatch.Stop();
                Interlocked.Increment(ref Dispose_Test.FinalizedObjects);
                Interlocked.Add(ref Dispose_Test.TotalTime, stopwatch.ElapsedMilliseconds);

                if(disposing)
                {
                    // called from user code
                    // can do anything 
                }
                else
                {
                    //called from finalizer
                    // do not access other references, run this code quick 
                }

                isDisposed = true;
            }
        }
        ~WithDispose()
        {
            Dispose(false);

        }
    }

    public class WithoutDispose
    {
        private Stopwatch stopwatch;

        public WithoutDispose()
        {
            stopwatch=new Stopwatch();
            stopwatch.Start();
        }
        public void DoWork()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    _ = i * j;
                }
            }
        }
        ~WithoutDispose()
        {
            stopwatch.Stop();
            Interlocked.Increment(ref Dispose_Test.FinalizedObjects);
            Interlocked.Add(ref Dispose_Test.TotalTime, stopwatch.ElapsedMilliseconds);

        }
    }

}
