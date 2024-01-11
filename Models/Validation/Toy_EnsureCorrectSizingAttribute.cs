using System.ComponentModel.DataAnnotations;

namespace ToysP.Models.Validation
{
    public class Toy_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var toy = validationContext.ObjectInstance as Toy;

            if (toy != null && !string.IsNullOrWhiteSpace(toy.Gender))
            {
                if (toy.Gender.Equals("boy", StringComparison.OrdinalIgnoreCase) && toy.Age < 8)
                {
                    return new ValidationResult("For boy toys, the size has to be greater or equal to 8.");
                }
                else if (toy.Gender.Equals("girl", StringComparison.OrdinalIgnoreCase) && toy.Age < 6)
                {
                    return new ValidationResult("For girl toys, the size has to be greater or equal to 6.");
                }
            }

            return ValidationResult.Success;
        }
    }
    
}
