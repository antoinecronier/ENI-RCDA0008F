using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo9.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            if (value.ToString().StartsWith("F"))
            {
                result = true;
            }
            
            return result;
        }
    }
}