using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {

        private static long m_money = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World !");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //耗时巨大的代码
            Task t = Task.Factory.StartNew(() =>
            {
                long ctr = 0;
                for (ctr = 0; ctr <= 1000000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });
            t.Wait();
            Task t1 = Task.Factory.StartNew(() =>
            {
                long ctr = 0;
                for (ctr = 0; ctr <= 1000000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });
            t1.Wait();

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("Stopwatch cost time:{0}ms.", ts.TotalMilliseconds);


            ThreadPool.SetMaxThreads(5, 5);

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            //耗时巨大的代码
            
            ThreadPool.QueueUserWorkItem(Runing, 1);  //            
            sw1.Stop();
            TimeSpan ts1 = sw1.Elapsed;
            Console.WriteLine("Stopwatch cost time:{0}ms.", ts1.TotalMilliseconds);

            //Thread.Sleep(1000);
            //Console.WriteLine(string.Format("Money: {0}", i));
            Console.ReadKey();
        }


        private static void Runing(object mParam)
        {
            //m_money += int.Parse(mParam.ToString());
            long i = 0;
            for (i = 0; i < 10000; i++)
            {

            }
        }
    }
}
