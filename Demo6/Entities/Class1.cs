using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo6.Entities
{
    public class Class1
    {
        private string prop1;
        private int prop2;
        private bool prop3;
        private Class1 prop4;

        public string Prop1 { get => prop1; set => prop1 = value; }
        public int Prop2 { get => prop2; set => prop2 = value; }
        public bool Prop3 { get => prop3; set => prop3 = value; }
        public Class1 Prop4 { get => prop4; set => prop4 = value; }

        public List<Class1> MyProperty { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
