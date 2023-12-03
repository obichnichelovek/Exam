using MangaLibraryAPI.Enumerators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibraryAPI.Entities;

public sealed class User
{
    #region Attributes
    [Required(ErrorMessage = "ID missing.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    #endregion
    public int ID { get; set; }
    #region Attributes
    [Required(ErrorMessage = "Name missing.")]
    [MaxLength(32, ErrorMessage = "Name length exceeded the allowed amount of characters ({1}).")]
    [MinLength(4, ErrorMessage = "Name length is lower than allowed ({1}).")]
    #endregion
    public string Name { get; set; } = null!;
    #region Attributes
    [Required(ErrorMessage = "Email missing.")]
    [MaxLength(48, ErrorMessage = "Email length exceeded the allowed amount of characters ({1}).")]
    [MinLength(4, ErrorMessage = "Email length is lower than allowed ({1}).")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ru)$")]
    [EmailAddress]
    #endregion
    public string Email { get; set; } = null!;
    #region Attributes
    [Required(ErrorMessage = "Password missing.")]
    [MaxLength(32, ErrorMessage = "Password length exceeded the allowed amount of characters ({1}).")]
    [MinLength(6, ErrorMessage = "Password length is lower than allowed ({1}).")]
    [PasswordPropertyText]
    #endregion
    public string Password { get; set; } = null!;
    public Roles Role { get; set; } = Roles.Standard;

    public ICollection<Manga> Mangas { get; set; } = new HashSet<Manga>();
}
