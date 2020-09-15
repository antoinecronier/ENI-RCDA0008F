using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public class Carre : Rectangle
    {
		public override int Largeur
		{
			get { return this.Longueur; }
		}
		public override string Print()
		{
			//StringBuilder builder = new StringBuilder();
			//builder.Append("Carré de côté = ");
			//builder.Append(Longueur);
			//Console.WriteLine(builder.ToString());

			//Console.WriteLine(String.Format("Carré de côté = {0} \n {1}", Longueur, base.ToString()));

			//Console.WriteLine($"Carré de côté = {Longueur} \n {base.ToString()}");

			return "Carré de côté = " + Longueur + "\n" + displayAP(Aire, Perimetre);
		}
	}
}
