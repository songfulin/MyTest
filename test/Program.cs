using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            //Demo8 a = new Demo8();
            //string a="1234";
            //Console.WriteLine(a.Substring(0,a.Length-1));


            #region  list 分页
            ////每页大小  
            //const int pageSize = 2;
            ////页码  
            //int pageNum = 0;
            ////源数据  
            //string[] names = { "贤静", "喵喵", "Monsoul", "柒夜", "钱卓文", "吴国军", "张三", "李四", "王五" };
            //while (pageNum * pageSize < names.Length)
            //{
            //    //分页  
            //    var query = names.Skip(pageSize * pageNum).Take(pageSize);
            //    Console.WriteLine("输出第{0}页记录", pageNum + 1);
            //    //输出每页内容  
            //    foreach (var q in query)
            //    {
            //        Console.WriteLine(q);
            //    }
            //    pageNum++;
            //}
            #endregion
            #region 
            
            #endregion
            Console.ReadKey();
        }


        /// <summary>
        /// string 与 stringbuilder replace relationship
        /// </summary>
        public void stringtest()
        {
            //System.Text.StringBuilder a = new StringBuilder();
            //a.Append("123456789");
            //Console.WriteLine(a.ToString());
            //a.Replace("1", "2");
            //Console.WriteLine(a.ToString());
            //Console.ReadKey();

            //string a = null;
            //a = "123456789";
            //Console.WriteLine(a.ToString());
            //a.Replace("1", "2");
            //Console.WriteLine(a.ToString());
            //Console.ReadKey();
             
        }
    }


    public class Demo8
    {
        ArrayList list = new ArrayList(1000000);
        public Demo8()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task2));
        }

        public void Task1(object obj)
        {
            lock (list.SyncRoot)
            {
                for (int i = 0; i < 500000; i++)
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Task1 count {0}", list.Count);
        }

        public void Task2(object obj)
        {
            lock (list.SyncRoot)
            {
                for (int i = 0; i < 500000; i++)
                {
                    list.Add(i);
                }
            }
            Console.WriteLine("Task2 count {0}", list.Count);
        }
    }
}
