using System.ComponentModel.DataAnnotations;

namespace webapi.Validation
{
    public class FirstLetterMayusAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) // Con esto hago que no se solape dos validaciones.
            {
                return ValidationResult.Success; // si es nulo, con esto lo dejo pasar y que sea otra regla de REQUIRED que actue
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper()) // si la primera letra no es mayuscula, retorne un error
            {
                return new ValidationResult("la primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
