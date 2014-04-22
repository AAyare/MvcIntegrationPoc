using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace MvcPoc.Web.Utils.CustomAttributes
{
    public class RequiredIfStateCodeIsAttribute : ValidationAttribute, IClientValidatable
    {
        public RequiredIfStateCodeIsAttribute(string stateCode, string specialStateCodes)
        {
            StateCode = stateCode;
            SpecialStateCodes = specialStateCodes;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                {
                    ErrorMessage = ErrorMessage,
                    ValidationType = "requiredifstatecodeis"
                };

            rule.ValidationParameters.Add("statecode", string.Format("#{0}", StateCode));
            rule.ValidationParameters.Add("specialstatecode", SpecialStateCodes);
            yield return rule;
        }

        public string SpecialStateCodes { get; private set; }
        public string StateCode { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(StateCode);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "{0} is an unknown property.", StateCode),
                    new[] {validationContext.MemberName}
                    );
            }

            var stateCodeValue = property.GetValue(validationContext.ObjectInstance, null);
            if(SpecialStateCodes.Contains(stateCodeValue.ToString()) && !string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(
                    FormatErrorMessage(validationContext.DisplayName),
                    new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}