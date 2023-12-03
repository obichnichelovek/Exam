namespace MangaLibraryAPI.Models;

public sealed class UserLogin
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = null!;
}
