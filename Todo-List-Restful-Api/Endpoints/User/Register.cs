using Microsoft.EntityFrameworkCore;
using DBEntityFrameworkCore;
using TodoList.Entitys;
public static class Register
{
    public static void MapRegisterEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/user");


        group.MapPost("/register", async (UserDtoRegisters userDto, ApplicationDbContext db) =>
        {
            var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (existingUser != null)
            {
                return Results.BadRequest("Email already exists");
            }
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = "User"
            };

            db.Add(user);
            await db.SaveChangesAsync();

            return Results.Ok($"User registered successfully");
        });
    }
}