using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebGrease.Css.Extensions;

namespace TPModule6_2.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString GenerateForm(this HtmlHelper htmlHelper, String formData)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"<form action=\"/{htmlHelper.ViewContext.RouteData.GetRequiredString("controller")}/{htmlHelper.ViewContext.RouteData.GetRequiredString("action")}\" method=\"post\" novalidate=\"novalidate\" >");
            result.Append(htmlHelper.AntiForgeryToken().ToString());

            result.Append($"{formData}");

            result.Append($"</form>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString FormBaseContent(this HtmlHelper htmlHelper, String title, String formData, String btnName)
        {
            StringBuilder result = new StringBuilder();

            result.Append($"<div class=\"form-horizontal\">");
            result.Append($"<h4>{title}</h4>");
            result.Append("<hr />");

            result.Append($"{formData}");

            if (btnName != null)
            {
                result.Append($"<div class=\"form-group\">");
                result.Append($"<div class=\"col-md-offset-2 col-md-10\" >");
                result.Append($"<input type = \"submit\" value=\"{btnName}\" class=\"btn btn-default\" />");
                result.Append($"</div>");
                result.Append($"</div>");
            }

            result.Append($"</div>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString AddAttributs(this HtmlHelper htmlHelper, Type type, string prefix, object data, bool isDiplay, String[] hiddenFields, String[] ignoringFields, List<PropertyListConstraint> propertyListConstraint)
        {
            StringBuilder result = new StringBuilder();

            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (!ignoringFields.Contains(property.Name)
                    && !hiddenFields.Contains(property.Name))
                {
                    result.Append($"<div class=\"form-group\">");

                    // Label for
                    result.Append($"<label class=\"control-label col-md-2\" for=\"{property.Name}\">{property.Name}</label>");

                    result.Append($"<div class=\"col-md-10\">");

                    //if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    if (propertyListConstraint != null && propertyListConstraint.SingleOrDefault(x => x.TargetProperty == property.Name) != null)
                    {
                        PropertyListConstraint constraint = propertyListConstraint.SingleOrDefault(x => x.TargetProperty == property.Name);

                        result.Append($"<select data-val=\"true\" class=\"form-control\" id=\"{ constraint.NewPropertyName }\" name=\"{ constraint.NewPropertyName }\"");
                        if (!constraint.IsMonoSelection)
                        {
                            result.Append($" multiple");
                        }
                        result.Append($">");

                        if (!String.IsNullOrEmpty(constraint.DefaultEmpty) && constraint.IsMonoSelection)
                        {
                            result.Append($"<option value=\"\">{ constraint.DefaultEmpty }</option>");
                        }
                        foreach (var item in constraint.Datas)
                        {
                            if (data != null && property.GetValue(data) != null && properties.FirstOrDefault(x => x.Name.Equals(property.Name)).GetValue(data) == null)
                            {
                                result.Append($" selected=\"selected\"");
                            }
                            else
                            {
                                result.Append($"<option value=\"{ item.Value }\"");
                                if (data != null)
                                {
                                    PropertyInfo prop = properties.FirstOrDefault(x => x.Name.Equals(property.Name));
                                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                                    {
                                        if (prop.GetValue(data) != null)
                                        {
                                            var test = prop.GetValue(data);
                                            List<BaseDbEntity> items = (test as IEnumerable<BaseDbEntity>).Cast<BaseDbEntity>().ToList();
                                            List<int> ids = items.Select(x => x.Id).ToList();
                                            if (ids.Contains(int.Parse(item.Value)))
                                            {
                                                result.Append($" selected=\"selected\"");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (prop != null
                                        && prop.GetValue(data) != null
                                        && int.Parse(prop.GetValue(data).GetType().GetProperty("Id").GetValue(prop.GetValue(data)).ToString()) == int.Parse(item.Value))
                                        {
                                            result.Append($" selected=\"selected\"");
                                        }
                                    }
                                }
                                
                                result.Append($">{ item.Text }</option> ");
                            }
                        }
                        result.Append($"</select>");
                    }
                    else
                    {
                        // Editor for
                        result.Append($"<input class=\"form-control text-box single-line\" id=\"{property.Name}\" name=\"{prefix + property.Name}\" ");

                        // Type assignation refer to https://www.w3schools.com/tags/att_input_type.asp
                        if (property.PropertyType == typeof(String))
                        {
                            result.Append($"type=\"text\" ");
                        }
                        else if (property.PropertyType == typeof(int))
                        {
                            result.Append($"type=\"number\" ");
                        }

                        if (data != null && property.GetValue(data) != null)
                        {
                            result.Append($"value=\"{property.GetValue(data).ToString()}\"");
                        }
                        else
                        {
                            result.Append($"value=\"\"");
                        }
                        if (isDiplay)
                        {
                            result.Append($" disabled");
                        }

                        result.Append($">");
                    }

                    result.Append($"</div>");

                    result.Append($"</div>");
                }
                if (data != null && hiddenFields.Contains(property.Name) && property.GetValue(data) != null)
                {
                    result.Append($"<input type=\"hidden\" ");
                    result.Append($"name = \"{prefix + property.Name}\" ");
                    result.Append($"value=\"{property.GetValue(data).ToString()}\"");
                    result.Append($">");
                }
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}