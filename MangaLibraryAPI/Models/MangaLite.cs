using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Enumerators;

namespace MangaLibraryAPI.Models;

public sealed class MangaLite
{
    public int ID { get; set; }
    public string TitleEnglish { get; set; } = null!;
    public string TitleJapanese { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public Status Status { get; set; }
    public float Rating { get; set; }
    public short ReleaseYear { get; set; }
    public Bookmark Bookmark { get; set; } = Bookmark.None;
    public string Poster { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
