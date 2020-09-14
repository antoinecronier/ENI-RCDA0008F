using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Entities
{
    public class Role : IDisplayable
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Show()
        {
            Console.WriteLine(String.Format("{0}", this.Name));
        }
    }
}
