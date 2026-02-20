using Microsoft.EntityFrameworkCore;
using DBEntityFrameworkCore;

public static class AdminEnd
{
    public static void MapAdminEndpoints(this WebApplication app)
    {
        app.MapGet("/admin/promote/{id}", async (ApplicationDbContext db, int id) =>
        {
            var user = await db.Users.FindAsync(id);
            if (user is null) return Results.NotFound("User not found");
            if (user.Role == "Admin") return Results.BadRequest("User is already an admin");

            user.Role = "Admin";
            await db.SaveChangesAsync();

            return Results.Ok($"User {user.Name} promoted to admin successfully");
        });


        app.MapGet("/admin/demote/{id}", async (ApplicationDbContext db, int id) =>
        {
            var user = await db.Users.FindAsync(id);
            if (user is null) return Results.NotFound("User not found");
            if (user.Role == "User") return Results.BadRequest("User is already a regular user");

            user.Role = "User";
            await db.SaveChangesAsync();

            return Results.Ok($"User {user.Name} demoted to regular user successfully");
        }).RequireAuthorization(policy => policy.RequireRole("Admin"));


        app.MapDelete("/admin/delete/{id}", async (ApplicationDbContext db, int id) =>
        {
            var user = await db.Users.FindAsync(id);
            if (user is null) return Results.NotFound("User not found");

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Results.Ok($"User {user.Email} deleted successfully");
        }).RequireAuthorization(policy => policy.RequireRole("Admin"));

        app.MapGet("/admin/users", async (ApplicationDbContext db) =>
        {
            var users = await db.Users.Select(u => new { u.Id, u.Name, u.Email, u.Role }).ToListAsync();
            return Results.Ok(users);
        }).RequireAuthorization(policy => policy.RequireRole("Admin"));

    }
}