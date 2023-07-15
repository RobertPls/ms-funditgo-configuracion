using Domain.ValueObjects;
using Shared.Core;
using Shared.Rules;

namespace Domain.Model
{

    public class ApplicationFile : AggregateRoot<Guid>
    {
        public FileNameValue FileName { get; private set; }
        public string Location { get; private set; }
        public string Extension { get; private set; }
        public string MimeType { get; private set; }
        public DateTime UploadedOn { get; private set; }
        public bool IsTemp { get; private set; }

        public int TimesUsed { get; private set; }

        public ApplicationFile(string fileName, string location, string extension, string mimeType, DateTime uploadedOn)
        {
            CheckRule(new StringNotNullOrEmptyRule(location));

            FileName = fileName;
            Location = location;
            Extension = extension;
            MimeType = mimeType;
            UploadedOn = uploadedOn;
            TimesUsed = 0;
            IsTemp = true;
        }
        public void IncreaseUsage()
        {
            TimesUsed++;
            IsTemp = false;
        }

        public void DecreaseUsage()
        {
            TimesUsed--;
            if (TimesUsed == 0)
            {
                IsTemp = true;
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ApplicationFile() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
