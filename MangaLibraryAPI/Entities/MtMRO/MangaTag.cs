namespace MangaLibraryAPI.Entities.MtMRO;

public sealed class MangaTag : MangaMain
{
    public int TagID { get; set; }
    public Tag Tag { get; set; } = null!;
}
