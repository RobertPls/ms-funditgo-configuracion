using Shared.Core;
using Shared.Rules;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    public record NombreRequerimientoValue : ValueObject
    {
        public string NombreRequerimiento { get; init; }

        public NombreRequerimientoValue(string nombreRequerimiento)
        {
            CheckRule(new StringNotNullOrEmptyRule(nombreRequerimiento));
            if (nombreRequerimiento.Length > 30)
            {
                throw new BussinessRuleValidationException("NombreRequerimiento no puede tener mas de 30 caracteres");
            }
            NombreRequerimiento = nombreRequerimiento;
        }

        public static implicit operator string(NombreRequerimientoValue value)
        {
            return value.NombreRequerimiento;
        }

        public static implicit operator NombreRequerimientoValue(string nombreRequerimiento)
        {
            return new NombreRequerimientoValue(nombreRequerimiento);
        }
    }
}
