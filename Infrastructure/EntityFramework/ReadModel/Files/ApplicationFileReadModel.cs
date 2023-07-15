using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EntityFramework.ReadModel.Files;

[Table("applicationFile", Schema = "app")]
internal class ApplicationFileReadModel
{
    [Key]
    [Column("fileId")]
    public Guid Id { get; set; }

    [Required]
    [Column("fileName")]
    [MaxLength(250)]
    public string FileName { get; set; }

    [Required]
    [Column("location")]
    [MaxLength(2000)]
    public string Location { get; set; }

    [Required]
    [Column("extension")]
    [MaxLength(50)]
    public string Extension { get; set; }

    [Required]
    [Column("mimeType")]
    [MaxLength(50)]
    public string MimeType { get; set; }
    
    [Required]
    [Column("uploadedOn")]
    public DateTime UploadedOn { get; set; }

    [Required]
    [Column("timesUsed")]
    [DefaultValue(0)]
    public int TimesUsed { get; set; }

    [Required]
    [Column("isTemp")]
    public bool IsTemp { get; private set; }

    public ApplicationFileReadModel()
    {
        FileName = "";
        Location = "";
        Extension = "";
        MimeType = "";
        UploadedOn = DateTime.Now;
        TimesUsed = 0;
        IsTemp = true;
    }
}
