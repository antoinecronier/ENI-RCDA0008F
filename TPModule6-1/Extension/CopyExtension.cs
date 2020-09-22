using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TPModule6_1.Extension
{
    public static class CopyExtension
    {
        public static void CopyIn(this object toItem, object fromItem)
        {
            PropertyInfo[] propertiesToItem = toItem.GetType().GetProperties();
            PropertyInfo[] propertiesFromItem = fromItem.GetType().GetProperties();
            propertiesToItem = propertiesToItem.OrderBy(x => x.Name).ToArray();
            propertiesFromItem = propertiesFromItem.OrderBy(x => x.Name).ToArray();

            for (int i = 0; i < propertiesToItem.Length; i++)
            {
                if (propertiesToItem[i].Name.Equals(propertiesFromItem[i].Name))
                {
                    propertiesToItem[i].SetValue(toItem, propertiesFromItem[i].GetValue(fromItem));
                }
            }
        }
    }
}