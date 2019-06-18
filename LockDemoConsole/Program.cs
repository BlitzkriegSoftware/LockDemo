using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LockDemoConsole
{
    class Program
    {

        public static Random dice = new Random();

        static void Main(string[] args)
        {
            Parallel.Invoke
            (
                () => TaskUnlocked(10),
                () => TaskWithLock(0),
                () => TaskUnlocked(3),
                () => TaskWithLock(1),
                () => TaskWithLock(8),
                () => TaskUnlocked(2),
                () => TaskWithLock(5),
                () => TaskUnlocked(4),
                () => TaskWithLock(6),
                () => TaskWithLock(7),
                () => TaskUnlocked(9),
                () => TaskWithLock(11)
           );

            Console.WriteLine("Please wait... press ENTER to end");
            Console.ReadLine();
        }

        private static void TaskWithLock(Object ThreadNumber)
        {
            string ThreadName = "L-Thread " + ThreadNumber.ToString();
            lock (typeof(Models.Locker_Lock_01))
            {
                Console.WriteLine("Enter: {0}", ThreadName);
                Thread.Sleep(dice.Next(50, 200));
                Console.WriteLine("Exit: {0}", ThreadName);
            }
        }

        private static void TaskUnlocked(Object ThreadNumber)
        {
            string ThreadName = "U-Thread " + ThreadNumber.ToString();
            Console.WriteLine("Enter: {0}", ThreadName);
            Thread.Sleep(dice.Next(20, 160));
            Console.WriteLine("Exit: {0}", ThreadName);
        }


    }
}
