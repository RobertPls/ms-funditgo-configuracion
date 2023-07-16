using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record TituloValue : ValueObject
    {
        public string Titulo { get; init; }

        public TituloValue(string titulo)
        {
            CheckRule(new StringNotNullOrEmptyRule(titulo));
            if (titulo.Length > 100)
            {
                throw new BussinessRuleValidationException("Titulo no puede tener mas de 100 caracteres");
            }
            Titulo = titulo;
        }

        public static implicit operator string(TituloValue value)
        {
            return value.Titulo;
        }

        public static implicit operator TituloValue(string titulo)
        {
            return new TituloValue(titulo);
        }
    }
}
