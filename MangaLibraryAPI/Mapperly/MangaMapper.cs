using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Models;
using Riok.Mapperly.Abstractions;

namespace MangaLibraryAPI.Mapperly;

[Mapper]
public partial class MangaMapper
{
    public partial MangaLite MangaToMangaLite(Manga manga);
    public partial List<MangaLite> MangasToMangaLites(List<Manga> manga);
}
