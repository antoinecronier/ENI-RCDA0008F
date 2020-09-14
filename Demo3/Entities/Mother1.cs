using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Entities
{
    public abstract class Mother1 : Interface2
    {
        public abstract void DoSmt1();

        public int DoSmt2()
        {
            return 2;
        }

        protected void DoSmt3()
        {
            Console.WriteLine("DoSmt3 - Mother1");
        }

        public virtual void DoSmt4()
        {
            Console.WriteLine("DoSmt4 - Mother1");
        }

        public void DoSmt7()
        {
            Console.WriteLine("DoSmt7 - Mother1");
        }

        public void DoSmt5()
        {
            Console.WriteLine("DoSmt5 - Mother1");
        }

        public int DoSmt6()
        {
            Console.WriteLine("DoSmt6 - Mother1");
            return 0;
        }
    }
}
