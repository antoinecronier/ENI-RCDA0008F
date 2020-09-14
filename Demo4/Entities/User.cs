using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Entities
{
    public class User : IDisplayable
    {
        private String firstname;
        private String lastname;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }

        public void Show()
        {
            Console.WriteLine(String.Format("{0} : {1}", this.Firstname, this.Lastname));
        }
    }
}
