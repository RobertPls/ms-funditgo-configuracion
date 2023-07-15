using Domain.Model;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.WriteConfig.Files;

internal class ApplicationFileConfig : IEntityTypeConfiguration<ApplicationFile>
{
    public void Configure(EntityTypeBuilder<ApplicationFile> builder)
    {
        builder.ToTable("applicationFile", "app");
        builder.Property(x => x.Id).HasColumnName("fileId");

        var fileNameConverter = 
            new ValueConverter<FileNameValue, string>(
                valueObject => valueObject.FileName, 
                stringValue => new FileNameValue(stringValue)
            );
        builder.Property(x => x.FileName).HasConversion(fileNameConverter).HasColumnName("fileName");
        
        builder.Property(x => x.Location).HasColumnName("location");
        builder.Property(x => x.Extension).HasColumnName("extension");
        builder.Property(x => x.MimeType).HasColumnName("mimeType");
        builder.Property(x => x.UploadedOn).HasColumnName("uploadedOn");
        builder.Property(x => x.TimesUsed).HasColumnName("timesUsed");
        builder.Property(x => x.IsTemp).HasColumnName("isTemp");

        builder.Ignore("_domainEvents");
        builder.Ignore(x => x.DomainEvents);
    }
}
