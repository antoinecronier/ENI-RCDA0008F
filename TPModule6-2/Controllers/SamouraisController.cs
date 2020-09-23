using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TPModule6_2.Data;
using TPModule6_2.Models;

namespace TPModule6_2.Controllers
{
    public class SamouraisController : BaseMVCController<Samourai, SamouraiViewModel>
    {
        protected override void LoadVMCreate(SamouraiViewModel vm)
        {
            List<int> armeIds = db.Samourais.Where(x => x.Arme != null).Select(x => x.Arme.Id).ToList();
            vm.Armes = db.Armes.Where(x => !armeIds.Contains(x.Id)).ToList();
            vm.ArtMartials.AddRange(db.ArtMartials.ToList());
        }

        protected override void PreDataCreateSave(SamouraiViewModel vm)
        {
            if (vm.IdSelectedArme != null)
            {
                var samouraisAvecMonArme = db.Samourais.Where(x => x.Arme.Id == vm.IdSelectedArme).ToList();

                foreach (var item in samouraisAvecMonArme)
                {
                    item.Arme = null;
                    db.Entry(item).State = EntityState.Modified;
                }

                vm.Samourai.Arme = db.Armes.Find(vm.IdSelectedArme);
            }

            vm.Samourai.ArtMartials = db.ArtMartials.Where(x => vm.ArtMartialsIds.Contains(x.Id)).ToList();
        }

        protected override Samourai GetVMItem(SamouraiViewModel vm)
        {
            return vm.Samourai;
        }

        protected override void LoadVMEdit(SamouraiViewModel vm)
        {
            List<int> armeIds = db.Samourais.Where(x => x.Arme != null && x.Id != vm.Samourai.Id).Select(x => x.Arme.Id).ToList();
            vm.Armes = db.Armes.Where(x => !armeIds.Contains(x.Id)).ToList();
            if (vm.Samourai.Arme != null)
            {
                vm.IdSelectedArme = vm.Samourai.Arme.Id;
            }

            vm.ArtMartials.AddRange(db.ArtMartials.ToList());
            vm.ArtMartialsIds = vm.Samourai.ArtMartials.Select(x => x.Id).ToList();
        }

        protected override SamouraiViewModel EditItemLoader(int? id)
        {
            SamouraiViewModel vm = new SamouraiViewModel();
            vm.Samourai = db.Samourais.Find(id);

            return vm;
        }

        protected override bool EditItemValidation(SamouraiViewModel vm)
        {
            bool result = true;

            if (vm.Samourai != null)
            {
                result = false;
            }

            return result;
        }

        protected override void PreDataEditUpdate(SamouraiViewModel vm)
        {
            var currentSamourai = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == vm.Samourai.Id);
            
            currentSamourai.Force = vm.Samourai.Force;
            currentSamourai.Nom = vm.Samourai.Nom;

            if (vm.IdSelectedArme != null)
            {
                var samouraisAvecMonArme = db.Samourais.Where(x => x.Arme.Id == vm.IdSelectedArme).ToList();

                Arme arme = null;
                foreach (var item in samouraisAvecMonArme)
                {
                    arme = item.Arme;
                    item.Arme = null;
                    db.Entry(item).State = EntityState.Modified;
                }

                if (arme == null)
                {
                    currentSamourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme);
                }
                else
                {
                    currentSamourai.Arme = arme;
                }
            }
            else
            {
                currentSamourai.Arme = null;
            }

            foreach (var item in currentSamourai.ArtMartials)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            currentSamourai.ArtMartials = db.ArtMartials.Where(x => vm.ArtMartialsIds.Contains(x.Id)).ToList();

            vm.Samourai = currentSamourai;
        }

        protected override void PreDeleteAction(Samourai item)
        {
            foreach (var artMartial in item.ArtMartials)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            item.ArtMartials.Clear();
        }
    }
}
