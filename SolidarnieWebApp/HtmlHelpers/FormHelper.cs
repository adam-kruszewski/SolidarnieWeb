using System.Linq;
using System.Reflection;
using System.Text;
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
            string actionName,
            string controllerName,
            object model,
            string akcjaAnuluj = null)
        {
            return new HelperResult(writer =>
            {
            using (helper.BeginForm(actionName, controllerName, FormMethod.Post))
                {
                    helper.AntiForgeryToken();
                    writer.WriteLine("<div class=\"form-horizontal\">");
                    writer.WriteLine("<hr/>");

                    writer.WriteLine(helper.ValidationSummary(true, "", new { @class = "text-danger" }));

                    writer.WriteLine(helper.GenerujEditorForObject(model).ToString());
                    writer.WriteLine(helper.GenerujPrzyciskiFormularza(akcjaAnuluj));

                    writer.Write("</div>");
                }
            });
        }

        public static HelperResult GenerujEditorForObject(
            this HtmlHelper helper,
            object model)
        {
            return new HelperResult(writer =>
            {
                foreach (var prop1 in model.GetType().GetProperties())
                {
                    writer.Write("<div class=\"form-group\">");
                    var b = WyswietlacLabel(prop1.Name, helper.ViewData);
                    if (Wyswietlac(prop1))
                        writer.Write(helper.Label(prop1.Name, new { @class = "control-label col-md-2" }).ToString());

                    writer.Write("<div class=\"col-md-10\">");
                    writer.Write(helper.Editor(prop1.Name, new { @class = "form-control" }).ToString());
                    writer.Write(helper.ValidationMessage(prop1.Name, "", new { @class = "text-danger" }));
                    writer.Write("</div>");
                    writer.Write("</div>");
                }
            });
        }

        public static MvcHtmlString GenerujPrzyciskiFormularza(
            this HtmlHelper helper,
            string akcjaAnuluj)
        {
            var tagBuilderFormGroup = new TagBuilder("div");
            tagBuilderFormGroup.AddCssClass("form-group");

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("col-md-offset-2");
            tagBuilder.AddCssClass("col-md-10");

            var przyciskiBuilder = new TagBuilder[2];

            var builderZapisz = PrzygotujBuilderaPrzyciskuZapisz();

            var builderAnuluj = PrzygotujBuilderaPrzyciskuAnuluj(akcjaAnuluj);

            przyciskiBuilder[0] = builderZapisz;
            przyciskiBuilder[1] = builderAnuluj;

            var stringBuilder = new StringBuilder();
            foreach (var builder in przyciskiBuilder)
            {
                stringBuilder.AppendLine(builder.ToString());
            }
            tagBuilder.InnerHtml = stringBuilder.ToString();

            tagBuilderFormGroup.InnerHtml = tagBuilder.ToString();

            return new MvcHtmlString(tagBuilderFormGroup.ToString());
        }

        private static TagBuilder PrzygotujBuilderaPrzyciskuAnuluj(string akcjaAnuluj)
        {
            var builderAnuluj = new TagBuilder("a");
            builderAnuluj.Attributes.Add("href", akcjaAnuluj);
            builderAnuluj.AddCssClass("btn");
            builderAnuluj.AddCssClass("btn-default");
            builderAnuluj.AddCssClass("btn-sm");
            builderAnuluj.InnerHtml = "Anuluj";
            return builderAnuluj;
        }

        private static TagBuilder PrzygotujBuilderaPrzyciskuZapisz()
        {
            var builderZapisz = new TagBuilder("input");
            builderZapisz.Attributes.Add("type", "submit");
            builderZapisz.Attributes.Add("value", "Zapisz");
            builderZapisz.Attributes.Add("class", "btn btn-default btn-sm btn-primary");
            return builderZapisz;
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