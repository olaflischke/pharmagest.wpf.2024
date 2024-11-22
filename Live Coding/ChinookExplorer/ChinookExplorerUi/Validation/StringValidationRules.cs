using System.Globalization;
using System.Windows.Controls;

namespace ChinookExplorerUi.Validation;

public class StringNotEmptyValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string? text = value?.ToString();

        if (string.IsNullOrWhiteSpace(text))
        {
            return new ValidationResult(false, "Text darf nicht leer sein!");
        }

        return new ValidationResult(true, null);
    }
}

public class StringLengthValidationRule : ValidationRule
{
    public int Minimum { get; set; }
    public int Maximum { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string? text = value?.ToString();

        if (string.IsNullOrWhiteSpace(text) || text.Length < Minimum || text.Length > Maximum)
        {
            return new ValidationResult(false, "Text hat nicht die erforderliche Länge");
        }

        return new ValidationResult(true, null);
    }
}
