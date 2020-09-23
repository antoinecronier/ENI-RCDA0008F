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

namespace TPModule6_2.Controllers
{
    public class ArmesController : BaseMVCController<Arme, Arme>
    {
        protected override bool DeleteRejected(int? id)
        {
            bool result = false;

            List<int> ids = db.Samourais.Include(x => x.Arme).Where(x => x.Arme != null).Select(x => x.Arme.Id).ToList();
            if (ids.Contains(id.Value))
            {
                ModelState.AddModelError("", "Cette arme ne peut pas être supprimé parce qu'elle appartient au samourai \"" + db.Samourais.FirstOrDefault(x => x.Arme.Id == id.Value).Nom + "\"");
                result = true;
            }

            return result;
        }

    }
}
