using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TPModule5_2.Models;

namespace TPModule5_2.Helpers
{
    public static class MyHelpers
    {
        /// <summary>
        ///  Return new Button with :
        ///      <div class="form-group">
        ///        <div class="col-md-offset-2 col-md-10">
        ///          <input type = "submit" value="@name" class="btn btn-default" />
        ///        </div>
        ///      </div>
        /// </summary>
        /// <param name="name">Name to render.</param>
        /// <returns></returns>
        public static IHtmlString CustomSubmit(this HtmlHelper htmlHelper, String name)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<div class=\"form - group\">");
            result.Append("<div class=\"col-md-offset-2 col-md-10\">");
            result.Append($"<input type = \"submit\" value=\"{ name }\" class=\"btn btn - default\" />");
            result.Append("</div>");
            result.Append("</div>");

            return new MvcHtmlString(result.ToString());
        }
    }
}