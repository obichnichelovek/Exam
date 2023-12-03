using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Enumerators;
using MangaLibraryAPI.Mapperly;
using MangaLibraryAPI.Models;
using MangaLibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MangaLibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class MangaController : Controller
{
    private readonly MangaLibraryRepository _repo;
    private readonly MangaMapper _mapper = new();

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<MangaLite>>> GetMangas(string? name, int page = 1, int pageSize = 2)
    {
        var (mangas, metadata) = await _repo.GetMangasAsync(name, page, pageSize);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(_mapper.MangasToMangaLites(mangas));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteUser(string name)
    {
        var manga = _repo.GetMangaByName(name);
        if (manga is null) return NotFound();

        _repo.DeleteManga(manga);
        return Ok();
    }

    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<ActionResult<List<Manga>>> GetMangasAdvanced(string? name, string? author, string? artist, string? publishing, SearchOptions searchOption = SearchOptions.Alphabet, int page = 1, int pageSize = 2)
    //{
    //    var (mangas, metadata) = await _repo.GetMangasAdvancedAsync(name, author, artist, publishing, searchOption, page, pageSize);
    //    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

    //    return Ok(mangas);
    //}

    public MangaController(MangaLibraryRepository repository)
    {
        _repo = repository;
    }
}
