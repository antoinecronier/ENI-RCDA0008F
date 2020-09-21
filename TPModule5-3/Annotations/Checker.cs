using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using TPModule5_3.Utils;
using TPModule5_3_BO;

namespace TPModule5_3.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class Checker : Attribute
    {
        public enum CheckerAction
        {
            Length,
            Required,
            DatasOccurs,
            NotSame
        }

        private string[] propertyName;
        private CheckerAction[] actions;

        public int LengthMax { get; set; } = 0;
        public int LengthMin { get; set; } = 0;
        public int OccurMax { get; set; } = 0;
        public int OccurMin { get; set; } = 0;

        public Checker(string[] propertyName, params CheckerAction[] actions)
        {
            this.propertyName = propertyName;
            this.actions = actions;
        }

        public bool Validate(object item, PropertyInfo property, bool result, ModelStateDictionary modelState)
        {
            if (actions.Contains(CheckerAction.Length))
            {
                result = Length(item, property, result, modelState);
            }
            if (actions.Contains(CheckerAction.Required))
            {
                result = Required(item, property, result, modelState);
            }
            if (actions.Contains(CheckerAction.DatasOccurs))
            {
                result = DataOccurs(item, property, result, modelState);
            }

            return result;
        }


        public bool Validate(object item, PropertyInfo property, bool result, ModelStateDictionary modelState, List<Pizza> referedList)
        {
            result = this.Validate(item, property, result, modelState);

            if (actions.Contains(CheckerAction.NotSame))
            {
                result = NotSame(item, property, result, modelState, referedList);
            }

            return result;
        }

        private bool NotSame(object item, PropertyInfo property, bool result, ModelStateDictionary modelState, List<Pizza> referedList)
        {
            PropertyInfo propertyToUse;
            object itemToUse;
            AssignDatas(item, property, out propertyToUse, out itemToUse);
            List<int> items = propertyToUse.GetValue(itemToUse) as List<int>;

            if (referedList.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(items.Select(y => int.Parse(y.ToString())).OrderBy(z => z))))
            {
                modelState.AddModelError(propertyToUse.Name, $"{propertyToUse.Name} ne doit pas être identique");
                result = false;
            }

            return result;
        }

        private bool DataOccurs(object item, PropertyInfo property, bool result, ModelStateDictionary modelState)
        {
            PropertyInfo propertyToUse;
            object itemToUse;
            AssignDatas(item, property, out propertyToUse, out itemToUse);

            int nbOccur = FakeDb.Instance.Pizzas.Count(x => x.Nom == propertyToUse.GetValue(itemToUse) as String);
            if (nbOccur < OccurMin || nbOccur > OccurMax)
            {
                modelState.AddModelError(propertyToUse.Name, $"La valeur de {propertyToUse.Name} apparu {nbOccur} fois ne doit apparaitre que dans l'interval [{OccurMin};{OccurMax}]");
                result = false;
            }

            #region Try
            //foreach (var dataProperty in FakeDb.Instance.GetType().GetProperties())
            //{
            //    if (dataProperty.PropertyType.IsGenericType && dataProperty.PropertyType.GenericTypeArguments[0] == property.PropertyType)
            //    {
            //        var data = dataProperty.GetValue(FakeDb.Instance);
            //        int countProp = 0;
            //        try
            //        {
            //            (data as IList).GetEnumerator().MoveNext();
            //            using (IEnumerator<Pizza> enumerator = (data as IList).get.GetEnumerator())
            //            {

            //            }
            //            while (.Current != null)
            //            {
            //                if (
            //                    (data as IList).GetEnumerator().Current.GetType().GetProperty(propertyToUse.Name).GetValue(
            //                        (data as IList).GetEnumerator().Current) == propertyToUse.GetValue(itemToUse))
            //                {
            //                    countProp++;
            //                }
            //            (data as IList).GetEnumerator().MoveNext();
            //            }
            //            if (countProp < OccurMin || countProp > OccurMax)
            //            {
            //                result = false;
            //            }
            //            break;
            //        }
            //        catch (Exception)
            //        {
            //            break;
            //        }

            //    }
            //}
            #endregion

            return result;
        }

        private bool Required(object item, PropertyInfo property, bool result, ModelStateDictionary modelState)
        {
            PropertyInfo propertyToUse;
            object itemToUse;
            AssignDatas(item, property, out propertyToUse, out itemToUse);
            if (propertyToUse.GetValue(itemToUse) == null)
            {
                modelState.AddModelError(propertyToUse.Name, $"{propertyToUse.Name} ne doit pas être null");
                result = false;
            }

            return result;
        }

        private bool Length(object item, PropertyInfo property, bool result, ModelStateDictionary modelState)
        {
            PropertyInfo propertyToUse;
            object itemToUse;
            AssignDatas(item, property, out propertyToUse, out itemToUse);

            if (propertyToUse.PropertyType == typeof(String))
            {
                if (propertyToUse.GetValue(itemToUse) != null)
                {
                    if ((propertyToUse.GetValue(itemToUse) as String).Length < this.LengthMin ||
                    (propertyToUse.GetValue(itemToUse) as String).Length > this.LengthMax)
                    {
                        modelState.AddModelError(propertyToUse.Name, $"{propertyToUse.Name} avec la valeur {propertyToUse.GetValue(itemToUse)} doit être comprit entre {LengthMin} et {LengthMax}");
                        result = false;
                    }
                }
            }

            if (propertyToUse.PropertyType.IsGenericType && propertyToUse.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                if (propertyToUse.GetValue(itemToUse) != null)
                {
                    if ((propertyToUse.GetValue(itemToUse) as ICollection).Count < this.LengthMin ||
                    (propertyToUse.GetValue(itemToUse) as ICollection).Count > this.LengthMax)
                    {
                        modelState.AddModelError(propertyToUse.Name, $"{propertyToUse.Name} avec la valeur {propertyToUse.GetValue(itemToUse)} doit être comprit entre {LengthMin} et {LengthMax}");
                        result = false;
                    }
                }
            }

            return result;
        }

        private void AssignDatas(object item, PropertyInfo property, out PropertyInfo propertyToUse, out object itemToUse)
        {
            propertyToUse = null;
            itemToUse = null;
            if (this.propertyName == null || this.propertyName.Length == 0)
            {
                propertyToUse = property;
                itemToUse = item;
            }
            else
            {
                itemToUse = property.GetValue(item);
                //propertyToUse = itemToUse.GetType().GetProperty(this.propertyName);
                for (int i = 0; i < this.propertyName.Length; i++)
                {
                    propertyToUse = itemToUse.GetType().GetProperty(this.propertyName[i]);
                    if (i < this.propertyName.Length - 1)
                    {
                        itemToUse = propertyToUse.GetValue(itemToUse);
                    }
                }
            }
        }
    }
}