using MangaLibraryAPI.Entities.MtMRO;
using MangaLibraryAPI.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MangaLibraryAPI.Entities;

public sealed class Manga
{
    #region Attributes
    [Required(ErrorMessage = "ID missing.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    #endregion
    public int ID { get; set; }

    #region Attributes
    [Required(ErrorMessage = "English title missing.")]
    [MaxLength(256, ErrorMessage = "English title length exceeded the maximal allowed amount of characters (256).")]
    #endregion
    public string TitleEnglish { get; set; } = null!;

    #region Attributes
    [Required(ErrorMessage = "Japanese title missing.")]
    [MaxLength(256, ErrorMessage = "Japanese title length exceeded the maximal allowed amount of characters (256).")]
    #endregion
    public string TitleJapanese { get; set; } = null!;

    #region Attributes
    [Required(ErrorMessage = "Short description missing.")]
    [MaxLength(256, ErrorMessage = "Short description length exceeded the maximal allowed amount of characters (256).")]
    #endregion
    public string ShortDescription { get; set; } = null!;
    [Required(ErrorMessage = "Details missing.")]
    public MangaDetails Details { get; set; } = new();
    public Status Status { get; set; }

    #region Attributes
    [Required(ErrorMessage = "Rating missing.")]
    [Range(0.0f, 10.0f, ErrorMessage = "Rating size is smaller than zero or greater than ten.")]
    #endregion
    public float Rating { get; set; }

    #region Attribtes
    [Required(ErrorMessage = "Missing release year")]
    [Range(1900, 3000, ErrorMessage = "Publish year cannot be older than 1900 or newer than 3000")]
    #endregion
    public short ReleaseYear { get; set; }
    public Bookmark Bookmark { get; set; } = Bookmark.None;

    #region Attributes
    [Required(ErrorMessage = "Poster missing.")]
    [MaxLength(128, ErrorMessage = "Poster URL length exceeded the maximal allowed amount of characters (128)")]
    #endregion
    public string Poster { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    [JsonIgnore]
    public List<MangaGenre> MangaGenres { get; set; } = new();
    [JsonIgnore]
    public List<MangaTag> MangaTags { get; set; } = new();
}
