using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcPoc.Web.Utils.HtmlExtensions
{
	public static class HtmlExtensions
	{
        public static MvcHtmlString RadioButtonForEnum<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var names = Enum.GetNames(metaData.ModelType);
            var sb = new StringBuilder();
            foreach (var name in names)
            {
                var id = string.Format(
                    "{0}_{1}_{2}",
                    htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                    metaData.PropertyName,
                    name
                );

                string description = string.Empty;
                var memberInfo = metaData.ModelType.GetMember(name);
                var attributes = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                description = attributes.Any() ? ((System.ComponentModel.DescriptionAttribute) attributes[0]).Description : name;
                var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
                sb.AppendFormat(
                    "{2}<label for=\"{0}\">{1}</label>",
                    id,
                    HttpUtility.HtmlEncode(description),
                    radio
                );
            }
            return MvcHtmlString.Create(sb.ToString());
        }
	}
}