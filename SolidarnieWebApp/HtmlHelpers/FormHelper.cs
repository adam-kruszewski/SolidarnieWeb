using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.WebPages;

namespace SolidarnieWebApp.HtmlHelpers
{
    public static class FormHelper
    {
        public static HelperResult GenerujFormularz(
            this HtmlHelper helper,
            object model,
            ViewDataDictionary viewData)
        {
            return new HelperResult(writer =>
            {
                using (helper.BeginForm())
                {
                    helper.AntiForgeryToken();
                    writer.WriteLine("<div class=\"form-horizontal\">");
                    writer.WriteLine("<hr/>");

                    writer.WriteLine(helper.ValidationSummary(true, "", new { @class = "text-danger" }));

                    foreach (var prop1 in model.GetType().GetProperties())
                    {
                        writer.Write("<div class=\"form-group\">");
                        //if ()
                        var b = WyswietlacLabel(prop1.Name, viewData);
                        if (Wyswietlac(prop1))
                            writer.Write(helper.Label(prop1.Name, new { @class = "control-label col-md-2" }).ToString());

                        writer.Write("<div class=\"col-md-10\">");
                        writer.Write(helper.Editor(prop1.Name, new { @class = "form-control" }).ToString());
                        writer.Write(helper.ValidationMessage(prop1.Name, "", new { @class = "text-danger" }));
                        writer.Write("</div>");
                        writer.Write("</div>");
                    }
                    writer.Write("</div>");

                }
            });
        }

        private static bool Wyswietlac(PropertyInfo prop1)
        {
            var p = prop1.GetCustomAttribute<HiddenInputAttribute>();
            return p == null;
        }

        private static bool WyswietlacLabel(string propertyName, ViewDataDictionary viewData)
        {
            var metadata = viewData.ModelMetadata.Properties.Single(o => o.PropertyName == propertyName);
            return metadata.ShowForEdit
                //&& (!metadata.IsComplexType || IsSupportedComplexType(metadata))
                && !viewData.TemplateInfo.Visited(metadata);
        }


        public static MvcHtmlString Image(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
            //return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}