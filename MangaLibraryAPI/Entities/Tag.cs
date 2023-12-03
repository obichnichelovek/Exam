using MangaLibraryAPI.Entities.MtMRO;
using MangaLibraryAPI.Enumerators;
using MangaLibraryAPI.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MangaLibraryAPI.Entities;

public sealed class Tag
{
    [Required(ErrorMessage = "Tag missing.")]
    public Tags Tags { get; set; }

    [Required(ErrorMessage = "ID missing.")]
    [Key]
    public int ID { get; set; }
    [Required(ErrorMessage = "Name missing.")]
    [MaxLength(24, ErrorMessage = "Name length exceeded the allowed amount of characters ({1}).")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description missing.")]
    [MaxLength(256, ErrorMessage = "Description length exceeded the allowed amount of characters ({1}).")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Mangas missing.")]
    public ICollection<Manga> Mangas { get; set; } = new HashSet<Manga>();
    [JsonIgnore]
    public List<MangaTag> MangaTags { get; set; } = new();

    public Tag(Tags tag)
    {
        Tags = tag;
        ID = (int)tag;
        Name = Tools.FixCase(Tools.GetEnumName(tag));
        Description = Tools.GetEnumDescription(tag);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Tag() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
