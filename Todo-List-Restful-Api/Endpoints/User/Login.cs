using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DBEntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

public static class Login
{
    public static void MapLoginEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/user");

        group.MapPost("/login", async (UserDtoLogin userDto, ApplicationDbContext db, IConfiguration config) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email && u.Password == userDto.password);
            if (user == null)
            {
                return Results.BadRequest("Invalid email or password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return Results.Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        });
    }
}