using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibraryAPI.Entities;

public sealed class MangaDetails
{
    [ForeignKey("MangaID")]
    public Manga Manga { get; set; } = null!;
    public int MangaID { get; set; }

    #region Attributes
    [Required(ErrorMessage = "Romaji title missing.")]
    [MaxLength(256, ErrorMessage = "Romaji title length exceeded the maximal allowed amount of characters (256).")]
    #endregion
    public string TitleRomaji { get; set; } = null!;
    #region Attributes
    [Required(ErrorMessage = "Description missing.")]
    [MaxLength(1024, ErrorMessage = "Description length exceeded the maximal allowed amount of characters (1024).")]
    #endregion
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Author missing.")]
    public string Author { get; set; } = null!;
    [Required(ErrorMessage = "Artist missing.")]
    public string Artist { get; set; } = null!;
    [Required(ErrorMessage = "Publishing missing.")]
    public string Publishing { get; set; } = null!;

    [Required(ErrorMessage = "Votes missing.")]
    public int Votes { get; set; }

    [Required(ErrorMessage = "Volumes missing.")]
    public short Volumes { get; set; }
    [Required(ErrorMessage = "Chapters missing.")]
    public short Chapters { get; set; }

    [Required(ErrorMessage = "Publish date missing.")]
    public DateTime PublishDate { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}
