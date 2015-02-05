using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        public delegate int TakesAWhileDelegate(int data, int ms);

        private static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("Start");
            Thread.Sleep(ms);
            Console.WriteLine("End");
            return ++data;

        }

        private static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");
            TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
            Trace.Assert(dl != null, "Invalid object type");
            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);
        }

        public static void ThreadMain()
        {
            Console.WriteLine("Running a new thread");
        }

        static void Main(string[] args)
        {
            #region 投票
            //TakesAWhileDelegate dl = TakesAWhile;//注册方法
            //IAsyncResult ar = dl.BeginInvoke(1, 50, null, null);//调用方法
            //while (!ar.IsCompleted)//是否执行完毕
            //{
            //    Console.Write(".");
            //    Thread.Sleep(30);
            //}
            //int result = dl.EndInvoke(ar);
            //Console.WriteLine("result:{0}",result);
            #endregion
            #region 等待句柄
            //TakesAWhileDelegate dl = TakesAWhile;//注册方法
            //IAsyncResult ar = dl.BeginInvoke(1, 100, null, null);//调用方法
            //while (true)//是否执行完毕
            //{
            //    Console.Write(".");
            //    if (ar.AsyncWaitHandle.WaitOne(50, false))//等待50毫秒委托是否执行完毕
            //    {
            //        Console.WriteLine("Can get the result now");
            //        break;
            //    }
            //}
            //int result = dl.EndInvoke(ar);
            //Console.WriteLine("result:{0}", result);
            #endregion
            #region 异步回调  不懂

            //TakesAWhileDelegate dl = TakesAWhile;//注册方法
            //dl.BeginInvoke(1, 100, TakesAWhileCompleted, dl);//调用方法

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}

            //lamada  start
            //TakesAWhileDelegate dl = TakesAWhile;//注册方法
            //dl.BeginInvoke(1, 100, ar =>
            //{
            //    int result = dl.EndInvoke(ar);
            //    Console.WriteLine("result:{0}", result);
            //}, null);
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}
            //lamada  end
            #endregion

            #region Thread

            var t1 = new Thread(ThreadMain);
            t1.Start();
            Console.WriteLine("this is  a main thread");
            //lamada版本 开始
            //var t1 = new Thread(() =>
            //{
            //    Console.WriteLine("Running a new Thread ,id:{0}", Thread.CurrentThread.ManagedThreadId);
            //    Console.WriteLine("启动一个新线程");
            //});
            //t1.Start();
            //Console.WriteLine("This is  Main Thread ,id:{0}", Thread.CurrentThread.ManagedThreadId);
            //结束
            #endregion
            Console.ReadKey();
        }


    }
}
