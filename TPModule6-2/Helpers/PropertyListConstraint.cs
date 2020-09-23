using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPModule6_2.Helpers
{
    public class PropertyListConstraint
    {
        public String TargetProperty { get; set; }
        public String NewPropertyName { get; set; }
        public bool IsMonoSelection { get; set; }
        public String DefaultEmpty { get; set; }
        public List<SelectListItem> Datas { get; set; }
    }
}