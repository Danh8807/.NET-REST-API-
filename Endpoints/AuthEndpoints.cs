using Microsoft.IdentityModel.Tokens;
using StudyAbroadApi.Data;
using StudyAbroadApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudyAbroadApi.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        // ── REGISTER ──────────────────────────────────────────────────────────
        app.MapPost("/api/auth/register", async (RegisterRequest req, AppDbContext db) =>
        {
            // Kiểm tra email đã tồn tại chưa
            if (db.Users.Any(u => u.Email == req.Email))
                return Results.BadRequest("Email đã được đăng ký.");

            // Hash password
            var hash = BCrypt.Net.BCrypt.HashPassword(req.Password);

            var user = new User
            {
                Email        = req.Email,
                PasswordHash = hash,
                Role         = "User"
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Results.Ok("Đăng ký thành công!");
        })
        .WithTags("Auth")
        .AllowAnonymous();

        // ── LOGIN ─────────────────────────────────────────────────────────────
        app.MapPost("/api/auth/login", (LoginRequest req, AppDbContext db, IConfiguration config) =>
        {
            // Tìm user theo email
            var user = db.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                return Results.Unauthorized();

            // Tạo JWT token
            var key      = config["Jwt:Key"]!;
            var issuer   = config["Jwt:Issuer"]!;
            var audience = config["Jwt:Audience"]!;
            var expiry   = int.Parse(config["Jwt:ExpiryMinutes"]!);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds      = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,  user.Email),
                new Claim(ClaimTypes.Role,  user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer:             issuer,
                audience:           audience,
                claims:             claims,
                expires:            DateTime.UtcNow.AddMinutes(expiry),
                signingCredentials: creds
            );

            return Results.Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        })
        .WithTags("Auth")
        .AllowAnonymous();
    }
}

public record RegisterRequest(string Email, string Password);
public record LoginRequest(string Email, string Password);