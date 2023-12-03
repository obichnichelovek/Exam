namespace MangaLibraryAPI.Entities.MtMRO;

public sealed class MangaGenre : MangaMain
{
    public int GenreID { get; set; }
    public Genre Genre { get; set; } = null!;
}
