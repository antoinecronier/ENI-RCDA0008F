using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public class Triangle : Forme
    {
		private int a;

		public int A
		{
			get { return a; }
			set { a = value; }
		}

		private int b;

		public int B
		{
			get { return b; }
			set { b = value; }
		}

		private int c;

		public int C
		{
			get { return c; }
			set { c = value; }
		}

		private double p => (A + B + C) / 2d;//rajouter d => / 2d

		public override double Aire => Math.Sqrt(p * (p - A) * (p - B) * (p - C));

		public override double Perimetre => A + B + C;

		public override string Print()
		{
			return "Triangle de côté A = " + A + " B = " + B + " C = " + C + "\n" + base.Print();
		}
	}
}
