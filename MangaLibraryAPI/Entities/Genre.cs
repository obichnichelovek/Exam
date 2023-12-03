using MangaLibraryAPI.Entities.MtMRO;
using MangaLibraryAPI.Enumerators;
using MangaLibraryAPI.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MangaLibraryAPI.Entities;

public sealed class Genre
{
    [Required(ErrorMessage = "Genre missing.")]
    public Genres Enum { get; set; }

    [Required(ErrorMessage = "ID missing.")]
    [Key]
    public int ID { get; set; }
    [Required(ErrorMessage = "Name missing.")]
    [MaxLength(24, ErrorMessage = "Name length exceeded the allowed amount of characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description missing.")]
    [MaxLength(256, ErrorMessage = "Description length exceeded the allowed amount of characters.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Mangas missing.")]
    public ICollection<Manga> Mangas { get; set; } = new HashSet<Manga>();
    [JsonIgnore]
    public List<MangaGenre> MangaGenres { get; set; } = new();

    public Genre(Genres genre)
    {
        Enum = genre;
        ID = (int)Enum;
        Name = Tools.GetCustomName(Enum) ?? Tools.FixCase(Tools.GetEnumName(Enum));
        Description = Tools.GetEnumDescription(Enum);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Genre() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}