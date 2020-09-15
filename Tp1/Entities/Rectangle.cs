using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public class Rectangle : Forme
    {
		private int longueur;

		public int Longueur
		{
			get { return longueur; }
			set { longueur = value; }
		}

		private int largeur;

		public virtual int Largeur
		{
			get { return largeur; }
			set { largeur = value; }
		}

		public override double Aire => Largeur * Longueur;

		public override double Perimetre => 2 * Largeur + 2 * Longueur;

		public override string Print()
		{
			return "Rectangle de longueur = " + Longueur + " et largeur = " + Largeur + "\n" + base.Print();
		}
	}
}
