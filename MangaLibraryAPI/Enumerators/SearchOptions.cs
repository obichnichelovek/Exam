namespace MangaLibraryAPI.Enumerators;

public enum SearchOptions : byte
{
    Alphabet = 1,
    AlphabetDescending,

    Rating,
    RatingDescending,

    Year,
    YearDescending,

    Add,
    AddDescending,

    Update,
    UpdateDescending
}
