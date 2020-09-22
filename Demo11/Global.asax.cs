using Demo11.Data;
using Demo11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;

namespace Demo11
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FillDb();
        }

        private void FillDb()
        {
            //using (var db = new Demo11Context())
            //{
            //    List<Permi> permis = new List<Permi>();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        permis.Add(new Entities.Permi() { Name = "Permi A", Points = 12 });
            //    }
            //    for (int i = 0; i < 10; i++)
            //    {
            //        permis.Add(new Entities.Permi() { Name = "Permi B", Points = 12 });
            //    }
            //    for (int i = 0; i < 10; i++)
            //    {
            //        permis.Add(new Entities.Permi() { Name = "Permi C", Points = 12 });
            //    }

            //    List<Conducteur> conducteurs = new List<Conducteur>();
            //    for (int i = 0; i < 20; i = i + 2)
            //    {
            //        conducteurs.Add(new Entities.Conducteur() { Firstname = "F" + i, Lastname = "L" + i, Permis = new List<Permi>() { permis.ElementAt(i), permis.ElementAt(i + 1) } });
            //    }

            //    List<Voiture> voitures = new List<Voiture>();
            //    for (int i = 0; i < 9; i++)
            //    {
            //        voitures.Add(new Voiture() { Name = "Voiture" + i, Driver = conducteurs.ElementAt(i), Drivers = new List<Conducteur>() { conducteurs.ElementAt(i), conducteurs.ElementAt(i + 1) } });
            //    }

            //    db.Permis.AddRange(permis);
            //    db.Conducteurs.AddRange(conducteurs);
            //    db.Voitures.AddRange(voitures);
            //    db.SaveChanges();
            //}

            using (var db = new Demo11Context())
            {
                db.Voitures.Where(x => x.Id < 5).ToList().ForEach(x => Console.WriteLine(x.Name));
                var v1 = db.Voitures.FirstOrDefault();
                Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(v1));
                Debug.WriteLine("-----------------------------------");
                var v2 = db.Voitures.Include(x => x.Driver).FirstOrDefault();
                Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(v2));
                Debug.WriteLine("-----------------------------------");
                var v3 = db.Voitures.Include(x => x.Driver).Include(x => x.Drivers).FirstOrDefault();
                Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(v3));
                Debug.WriteLine("-----------------------------------");
                var v4 = db.Voitures.Include(x => x.Driver.Permis).Include(x => x.Drivers.Select(z => z.Permis)).FirstOrDefault();
                Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(v4));
                Debug.WriteLine("-----------------------------------");
            }
        }
    }
}
