using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Enumerators;
using MangaLibraryAPI.Models;
using MangaLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MangaLibraryAPI.Controllers;

[Route("api/[controller]")]
[Authorize]
public sealed class UserController : ControllerBase
{
    private readonly MangaLibraryRepository _repo;

    [HttpGet("Admins")]
    public ActionResult<string> AdminEndpoint()
    {
        var user = GetCurrentUser();
        return Ok($"You are {user.Name} the {user.Role}");
    }

    [HttpDelete("Admins")]
    public ActionResult DeleteUser(UserLogin userLogin)
    {
        var user = _repo.GetUser(userLogin);
        if (user is null) return NotFound();

        _repo.DeleteUser(user);
        return Ok();
    }

    private User GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if (identity == null) throw new ArgumentNullException(nameof(identity), "User identity not found.");

        var claims = identity.Claims;
        return new User()
        {
            Name = claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)!.Value,
            Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value,
            Role = Tools.GetRole(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value)
        };
    }

    public UserController(MangaLibraryRepository repository)
    {
        _repo = repository;
    }
}
