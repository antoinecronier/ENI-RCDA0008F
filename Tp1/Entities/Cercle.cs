using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public class Cercle : Forme
    {
		private int rayon;

		public int Rayon
		{
			get { return rayon; }
			set { rayon = value; }
		}

		public override double Aire => Math.PI * Math.Pow(Rayon,2);

		public override double Perimetre
		{
			get { return 2 * Math.PI * Rayon; }
		}

		public override string Print()
		{
			return "Cercle de rayon " + Rayon + "\n" + base.Print();
		}
	}
}
