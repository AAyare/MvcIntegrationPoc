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

        public static MvcHtmlString IndexBasedEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression, Type ParentType, int indexToCreateElementAt,
                string collectionPropertyName)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var collectionObject = ParentType.GetProperties().First(p => p.Name.Equals(collectionPropertyName));
            
            if(!collectionObject.PropertyType.IsGenericType && collectionObject.PropertyType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
                throw new ArgumentException(string.Format("Parent Object does not contain a Generic Type property with name: {0}", collectionPropertyName));

            htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("{0}[{1}]", collectionObject.Name, indexToCreateElementAt);
            var id = string.Format("{0}__{2}",
                                   htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                                   indexToCreateElementAt, 
                                   metaData.PropertyName
                );

            var name = string.Format("{0}[{1}].{2}",
                                   collectionObject.Name,
                                   indexToCreateElementAt, 
                                   metaData.PropertyName
                );

            var htmlElement = htmlHelper.EditorFor(expression, name, new {id = @id}).ToHtmlString();
            return MvcHtmlString.Create(htmlElement);
        }

        public static MvcHtmlString IndexBasedHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression, Type ParentType, int indexToCreateElementAt,
                string collectionPropertyName)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var collectionObject = ParentType.GetProperties().First(p => p.Name.Equals(collectionPropertyName));
            
            if(!collectionObject.PropertyType.IsGenericType && collectionObject.PropertyType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
                throw new ArgumentException(string.Format("Parent Object does not contain a Generic Type property with name: {0}", collectionPropertyName));

            htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("{0}[{1}]", collectionObject.Name, indexToCreateElementAt);
            var id = string.Format("{0}__{2}",
                                   htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                                   indexToCreateElementAt, 
                                   metaData.PropertyName
                );

            var name = string.Format("{0}[{1}].{2}",
                                   collectionObject.Name,
                                   indexToCreateElementAt, 
                                   metaData.PropertyName
                );

            var htmlElement = htmlHelper.HiddenFor(expression, new {id = @id}).ToHtmlString();
            return MvcHtmlString.Create(htmlElement);
        }
	}
}