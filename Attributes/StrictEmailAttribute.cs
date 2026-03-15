using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

public class StrictEmailAttribute : ValidationAttribute, IClientValidatable
{
    private const string _pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    private static readonly Regex _regex = new Regex(_pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public StrictEmailAttribute()
    {
    }

    public override bool IsValid(object value)
    {
        var strValue = value as string;
        if (string.IsNullOrEmpty(strValue)) return true;

        return _regex.IsMatch(strValue);
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ValidationType = "strictemail",
            ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
        };

        rule.ValidationParameters.Add("pattern", _pattern);
        yield return rule;
    }
}