using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5
{
    public static class Extensions
    {
        public static int Add(this int a, int b)
        {
            return a + b;
        }
        public static void Add1(this int a, int b)
        {
            a = a + b;
        }
        public static void RunAsync(this Action a)
        {
            Task.Factory.StartNew(a);
        }
    }
}
