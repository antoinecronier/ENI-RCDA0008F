using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPModule5_3.Annotations
{
    public class IngredientLengthValidation : ValidationAttribute
    {
        private int min;
        private int max;

        public IngredientLengthValidation(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Les ingredients doivent être entre {this.min} et {this.max}";
        }

        public override bool IsValid(object value)
        {
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;
                if (maList.Count < this.min || maList.Count > this.max)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}