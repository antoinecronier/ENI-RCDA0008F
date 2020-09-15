using Demo6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> ints = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12,4};

            Console.WriteLine(ints.First(x => x == 4));
            Console.WriteLine(ints.FirstOrDefault(x => x == 41));

            Console.WriteLine(ints.Last(x => x == 4));
            Console.WriteLine(ints.LastOrDefault(x => x == 4));

            //Console.WriteLine(ints.Single(x => x == 4));
            Console.WriteLine(ints.SingleOrDefault(x => x == 41));
            //Console.WriteLine(ints.SingleOrDefault());

            List<Class1> class1s = new List<Class1>();
            for (int i = 0; i < 10; i++)
            {
                class1s.Add(new Class1 {Prop1 = "aze" + i, Prop2 = i * 2, Prop3 = i % 2 == 0, Prop4 = null });
            }

            foreach (var item in class1s.Where(x => x.Prop3))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");
            Console.WriteLine(class1s.Count);
            Class1 class1 = null;
            foreach (var item in class1s.Where(x => !x.Prop3 && x.Prop2 % 5 == 0))
            {
                Console.WriteLine(item);
                class1 = item;
            }
            class1s.Add(class1);
            Console.WriteLine(class1s.Count);
            Console.WriteLine("-------------");

            foreach (var item in class1s.Where(x => !x.Prop3 && x.Prop2 % 5 == 0).Distinct())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            foreach (var item in class1s.Take(3))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            List<string> strings = new List<string>() { "fdpjgpsodjgf", "adpjgpsodjgf", "kfpjgps", "mdjgpfdj", "cdogdf" };

            foreach (var item in strings.OrderBy(x => x.Length))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            foreach (var item in class1s.OrderByDescending(x => x.Prop1))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            foreach (var item in strings.OrderBy(x => x.Length).ThenBy(x => x))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            if(strings.All(x => x.Length > 2))
            {
                Console.WriteLine("Tout les éléments plus grand que 2");
            }
            else
            {
                Console.WriteLine("Des éléments moins grand que 2 existe");
            }

            if (strings.Any(x => x.Length > 6))
            {
                Console.WriteLine("il y a au moins un éléments plus grand que 6");
            }

            Console.WriteLine("-------------");

            foreach (var item in strings.Select(x => x + "aze"))
            {
                Console.WriteLine(item);
            }

            foreach (var item in strings.Select(x => new Class1 { Prop1 = x}))
            {
                Console.WriteLine(item);
            }

            //class1s.SelectMany(x => x.MyProperty)
            Console.WriteLine("-------------");

            foreach (IGrouping<string,Class1> item in class1s.GroupBy(x => x.Prop1))
            {
                Console.WriteLine(item.Key);
                foreach (var subitem in item)
                {
                    Console.WriteLine(subitem);
                }
                Console.WriteLine("/////////////");
            }

            Console.ReadKey();
        }
    }
}
