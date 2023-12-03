using MangaLibraryAPI.Entities;
using MangaLibraryAPI.Models;
using MangaLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MangaLibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly MangaLibraryRepository _repo;

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<string> Authenticate([FromQuery] UserLogin userLogin)
    {
        var user = _repo.GetUser(userLogin);
        if (user == null) return NotFound("User not found.");

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:SecurityKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        Claim[] claims = new Claim[4]
        {
            new("sub", user.ID.ToString()),
            new("given_name", user.Name),
            new("email", user.Email),
            new("role", Tools.GetRoleName(user.Role))
        };

        var jwtToken = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return Ok(token);
    }

    public AuthenticationController(IConfiguration configuration, MangaLibraryRepository repository)
    {
        _config = configuration;
        _repo = repository;
    }
}
