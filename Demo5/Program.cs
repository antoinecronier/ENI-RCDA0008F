using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action action1 = new Action(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            });

            action1.RunAsync();
            //for (int i = 0; i < 3; i++)
            //{
            //    Task.Factory.StartNew(action1);
            //}

            action1.Invoke();
            action1.Invoke();
            action1.Invoke();

            var action2 = new Action<string,string>((m, s) =>
            {
                Console.WriteLine(m + s);
            });

            action2.Invoke("Hello", "World");

            var func1 = new Func<int, int, double>((a, b) =>
              {
                  return a * b * 0.00000000001;
              });

            Console.WriteLine(func1.Invoke(6,8));

            var func2 = new Func<Action, string, Func<int>, int>((ac, str, fun) =>
            {
                return 0;
            });

            func2.Invoke(() => { }, "", () => { return 0; });

            int extA = 10;
            extA = extA.Add(10);
            Console.WriteLine(extA);

            int extB = 10;
            extB.Add1(10);
            Console.WriteLine(extB);

            Console.ReadKey();
        }
    }
}
