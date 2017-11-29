using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using SolidarnieWebApp.HtmlHelpers.Attributes;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.HtmlHelpers
{
    public static class TableHelper
    {
        public static HelperResult GenerujTable<T>(
            this HtmlHelper helper,
            List<T> model)
        {
            return new HelperResult(writer =>
            {
                writer.WriteLine("<table class=\"table\">");
                GenerujWierszNaglowkowy(writer, model);

                foreach (var wiersz in model)
                {
                    helper.GenerujWierszDlaModelu(writer, wiersz);
                }

                writer.Write("</table>");
            });

        }

        private static void GenerujWierszNaglowkowy<T>(
            TextWriter writer,
            IEnumerable<T> model)
        {
            writer.Write("<tr>");
            var propertiesy = typeof(T).GetProperties();
            foreach (var p in propertiesy)
                GenerujKolumneNaglowkowa(writer, p);

            writer.Write("</tr>");
        }

        private static void GenerujWierszDlaModelu<T>(
            this HtmlHelper helper,
            TextWriter writer,
            T wiersz)
        {
            writer.Write("<tr>");
            foreach (var p in typeof(T).GetProperties())
            {
                helper.GenerujKolumnaDlaPropertiesaModelu(writer, p, wiersz);
            }
            writer.Write("</tr>");
        }

        private static void GenerujKolumneNaglowkowa(TextWriter writer, PropertyInfo p)
        {
            if (!WyswietlacKolumne(p))
                return;

            writer.Write("<th>");
            writer.Write(DajOpisKolumny(p));
            writer.Write("</th>");
        }

        private static void GenerujKolumnaDlaPropertiesaModelu<T>(
            this HtmlHelper helper,
            TextWriter writer,
            PropertyInfo p,
            T wiersz)
        {
            if (!WyswietlacKolumne(p))
                return;

            var nazwaPartiala = "KomorkaTabeli";

            var uiHintAttribute = p.GetCustomAttribute<UIHintAttribute>();
            if (uiHintAttribute != null)
                nazwaPartiala = uiHintAttribute.UIHint;

            writer.Write("<td>");
            writer.Write(
                helper.Partial(
                    nazwaPartiala,
                    new KomorkaTabeliModel(wiersz, p.Name)
                    ));
            writer.Write("</td>");
        }

        private static bool WyswietlacKolumne(PropertyInfo p)
        {
            return p.GetCustomAttribute<UkrytaKolumnaAttribute>() == null;
        }

        private static string DajOpisKolumny(PropertyInfo p)
        {
            var atrybutDisplayName = p.GetCustomAttribute<DisplayNameAttribute>();
            if (atrybutDisplayName != null)
                return atrybutDisplayName.DisplayName;
            else
                return p.Name;
        }
    }
}