using Shared.Core;
using Shared.Rules;

namespace Shared.ValueObjects
{
    public record CantidadValue : ValueObject
    {
        public int Value { get; }

        public CantidadValue(int value)
        {
            CheckRule(new NotNullRule(value));
            if (value < 0)
            {
                throw new BussinessRuleValidationException("No puede ser menor a 0");
            }
            Value = value;
        }

        public static implicit operator int(CantidadValue value)
        {
            return value.Value;
        }

        public static implicit operator CantidadValue(int value)
        {
            return new CantidadValue(value);
        }
    }
}
