using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Rg.TagHelpers.Utilities
{
    public class PaginationTagHelper_Utilities
    {

        /// <summary>
        /// Get Html Content And Convert To String
        /// </summary>
        /// <param name="content"></param>
        /// <returns> String content </returns>
        public string ConvertHtmlToString(IHtmlContent content)
        {
            using (var writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Build a tag with classes
        /// </summary>
        /// <param name="Classes"></param>
        /// <param name="href"></param>
        /// <param name="content"></param>
        /// <returns> tag a </returns>
        public TagBuilder Create_Tag_a(string Classes, string href, string content)
        {
            var a = new TagBuilder("a");
            a.AddCssClass(Classes);
            a.MergeAttribute("href", href);
            a.InnerHtml.SetContent(content);
            return a;
        }
        /// <summary>
        /// Build the i tag with the internal tag a along with both tags classes
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Link"></param>
        /// <param name="AClasses"></param>
        /// <param name="LiClasses"></param>
        /// <returns> li tag with inner tag a </returns>
        public TagBuilder Create_Tag_li_with_inner_tag_a(string Text, string Link, string AClasses, string LiClasses)
        {
            var a = new TagBuilder("a");

            a.AddCssClass(AClasses);
            a.MergeAttribute("href", $"{Link}");
            a.InnerHtml.AppendHtml(Text);

            var li = new TagBuilder("li");

            li.AddCssClass(LiClasses);
            li.InnerHtml.AppendHtml(a);
            return li;
        }


        /// <summary>
        /// build div tag with classes
        /// </summary>
        /// <param name="Classes"></param>
        /// <returns> div tag </returns>
        public TagBuilder Create_Tag_div(string Classes)
        {
            var div = new TagBuilder("div");

            div.AddCssClass(Classes);
            return div;

        }



        /// <summary>
        /// buikd ul tag with classes
        /// </summary>
        /// <param name="classess"></param>
        /// <returns> ul tag </returns>
        public TagBuilder Create_Tag_ul(string classess)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass(classess);
            return ul;
        }

        /// <summary>
        /// build label tag with content
        /// </summary>
        /// <param name="content"></param>
        /// <returns>label tag</returns>
        public TagBuilder Create_Tag_label(string content)
        {
            var label = new TagBuilder("label");
            label.InnerHtml.SetContent(content);
            return label;
        }

        /// <summary>
        /// build button tag with classes && attributes && content
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="attributes"></param>
        /// <param name="content"></param>
        /// <returns>button tag </returns>
        public TagBuilder Create_Tag_button(string classes, IDictionary<string, string> attributes, string content)
        {
            var button = new TagBuilder("button");
            button.AddCssClass(classes);
            button.InnerHtml.SetContent(content);
            foreach (var attr in attributes)
            {
                button.MergeAttribute(attr.Key, attr.Value);
            }
            return button;
        }
    }
}
