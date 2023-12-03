using MangaLibraryAPI.DatabaseContexts;
using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Enumerators;
using MangaLibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MangaLibraryAPI.Services;

public sealed class MangaLibraryRepository
{
    private readonly MangaLibraryContext _context;

    public async Task<List<Manga>> GetMangasAsync(int page, int pageSize)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        return await collection.OrderBy(x => x.Rating).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
    }

    public async Task<(List<Manga>, PaginationMetadata)> GetMangasAsync(string? name, int page, int pageSize, bool includeDetails = false)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        if (!string.IsNullOrEmpty(name))
        {
            name = name.Trim();
            if (IsJapanese(name))
                collection = collection.Where(x => x.TitleJapanese.Contains(name));

            else
                collection = collection.Include(x => x.Details).Where(x => x.TitleEnglish.Contains(name) | x.Details.TitleRomaji.Contains(name));
        }

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.OrderBy(x => x.Rating).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();

        return (returnCollection, metadata);
    }

    //public async Task<(List<Manga>, PaginationMetadata)> GetMangasAdvancedAsync(string? name, string? author, string? artist, string? publishing, SearchOptions searchOption, int page, int pageSize)
    //{
    //    var collection = _context.Mangas as IQueryable<Manga>;


    //    if (!string.IsNullOrEmpty(name))
    //    {
    //        name = name.Trim();
    //        if (IsJapanese(name))
    //            collection = collection.Where(x => x.TitleJapanese.Contains(name));

    //        else
    //            collection = collection.Include(x => x.Details).Where(x => x.TitleEnglish.Contains(name) | x.Details.TitleRomaji.Contains(name));
    //    }

    //    if (!string.IsNullOrEmpty(author))
    //    {
    //        author = author.Trim();
    //        collection = collection.Include(x => x.Details).Where(x => x.Details.Author.Contains(author));
    //    }

    //    if (!string.IsNullOrEmpty(artist))
    //    {
    //        artist = artist.Trim();
    //        collection = collection.Include(x => x.Details).Where(x => x.Details.Artist.Contains(artist));
    //    }

    //    if (!string.IsNullOrEmpty(publishing))
    //    {
    //        publishing = publishing.Trim();
    //        collection = collection.Include(x => x.Details).Where(x => x.Details.Publishing.Contains(publishing));
    //    }

    //    var count = await collection.CountAsync();
    //    var metadata = new PaginationMetadata(count, pageSize, page);

    //    switch (searchOption)
    //    {
    //        case SearchOptions.Alphabet:
    //            collection = collection.OrderBy(x => x.TitleEnglish);
    //            break;
    //        case SearchOptions.AlphabetDescending:
    //            collection = collection.OrderByDescending(x => x.TitleEnglish);
    //            break;

    //        case SearchOptions.Rating:
    //            collection = collection.OrderBy(x => x.Rating);
    //            break;
    //        case SearchOptions.RatingDescending:
    //            collection = collection.OrderByDescending(x => x.Rating);
    //            break;

    //        case SearchOptions.Year:
    //            collection = collection.OrderBy(x => x.ReleaseYear);
    //            break;
    //        case SearchOptions.YearDescending:
    //            collection = collection.OrderByDescending(x => x.ReleaseYear);
    //            break;

    //        case SearchOptions.Add:
    //            collection = collection.Include(x => x.Details).OrderBy(x => x.Details.PublishDate);
    //            break;
    //        case SearchOptions.AddDescending:
    //            collection = collection.Include(x => x.Details).OrderByDescending(x => x.Details.PublishDate);
    //            break;
    //    }

    //    var returnCollection = await collection.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();

    //    return (returnCollection, metadata);
    //}
    public Manga? GetMangaByName(string name) => _context.Mangas.Where(x => x.TitleEnglish == name).FirstOrDefault();

    public void DeleteManga(Manga manga) => _context.Mangas.Remove(manga);
    public void DeleteUser(User user) => _context.Users.Remove(user);

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;

    public User? GetUser(UserLogin userLogin)
    {
        if (string.IsNullOrEmpty(userLogin.Name))
            return _context.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

        return _context.Users.FirstOrDefault(x => x.Name == userLogin.Name && x.Password == userLogin.Password);
    }

    private static bool IsJapanese(string text)
    {
        switch (text[0] >= 0x3000 && text[0] <= 0x303f)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x3040 && text[0] <= 0x309f)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x30a0 && text[0] <= 0x30ff)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x4e00 && text[0] <= 0x9faf)
        {
            case true: return true;
            default:
            case false: break;
        }

        return false;
    }

    public MangaLibraryRepository(MangaLibraryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
