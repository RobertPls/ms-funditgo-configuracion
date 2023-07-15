using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record FileNameValue : ValueObject
    {
        public string FileName { get; }

        public FileNameValue(string filename)
        {
            CheckRule(new StringNotNullOrEmptyRule(filename));

            string regex = @"^[\w\-. ]+$";
            CheckRule(new RegexRule("FileName", filename, regex));

            FileName = filename;
        }

        public static implicit operator string(FileNameValue value)
        {
            return value.FileName;
        }

        public static implicit operator FileNameValue(string name)
        {
            return new FileNameValue(name);
        }
    }
}
