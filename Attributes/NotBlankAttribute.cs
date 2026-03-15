using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.Attributes
{
    public class NotBlankAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            var strValue = value as string;
            return !string.IsNullOrWhiteSpace(strValue);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ValidationType = "notblank",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
        }
    }
}
