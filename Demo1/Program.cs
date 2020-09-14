using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public class Program
    {
        public static int test;
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Console.ReadKey();
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set {
                if (value > 5)
                {
                    myVar = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public int MyProperty1 { get; set; }

        public void Test()
        {
            MyProperty = 10;
            var test = MyProperty;
        }
    }
}
