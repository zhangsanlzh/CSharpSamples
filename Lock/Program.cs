﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    class Program
    {
        static List<int> list = new List<int>();

        [STAThread]
        static void Main(string[] args)
        {
            //Thread t0 = new Thread(new ThreadStart(delegate { AddToList(1, 10); }));
            //Thread t1 = new Thread(new ThreadStart(delegate { AddToList(11, 20); }));
            //Thread t2 = new Thread(new ThreadStart(delegate { AddToList(21, 30); }));
            //Thread t3 = new Thread(new ThreadStart(delegate { AddToList(31, 40); }));

            //t0.Start();
            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t0.Join();
            //t1.Join();
            //t2.Join();
            //t3.Join();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(DateTime.Now);

            ////顺序执行
            //new Action(async () =>
            //{
            //    await Delay3000Async();
            //    await Delay2000Async();
            //    await Delay1000Async();
            //})();

            ////异步执行
            //new Action(async () =>
            //{
            //    Delay3000Async();
            //    Delay2000Async();
            //    Delay1000Async();
            //})();

            //异步执行
            var task3 = Delay3000Async();
            var task2 = Delay2000Async();
            var task1 = Delay1000Async();
            new Action(async () =>
            {
                await task3;
                await task2;
                await task1;
            })();

            Console.WriteLine("hello");

            ////异步执行
            //var tasks = new List<Task>
            //{
            //    Delay3000Async(),
            //    Delay2000Async(),
            //    Delay1000Async()
            //};
            //tasks.ForEach(async s => await s);

            ////异步执行
            //Action[] actions = new Action[3]
            //{
            //    new Action(()=>{Delay3000Async(); }),
            //    new Action(()=>{Delay2000Async(); }),
            //    new Action(()=>{Delay1000Async(); })
            //};
            //Parallel.Invoke(actions);

            Console.ReadKey();
        }

        static void AddToList(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                lock (list)
                {
                    list.Add(i);
                }
            }
        }

        static async Task Delay3000Async()
        {
            await Task.Delay(3000);
            Console.WriteLine(3000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay2000Async()
        {
            await Task.Delay(2000);
            Console.WriteLine(2000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay1000Async()
        {
            await Task.Delay(1000);
            Console.WriteLine(1000);
            Console.WriteLine(DateTime.Now);
        }
    }
}
