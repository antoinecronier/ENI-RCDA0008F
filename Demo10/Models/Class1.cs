using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo10.Models
{
    public class Class1 : DbEntity
    {
        private string prop1;
        private string prop2;
        private int prop3;

        public string Prop1 { get => prop1; set => prop1 = value; }
        public string Prop2 { get => prop2; set => prop2 = value; }
        public int Prop3 { get => prop3; set => prop3 = value; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}