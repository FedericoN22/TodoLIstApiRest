using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DBEntityFrameworkCore;
using TodoList.Entitys;

public static class Item
{


    public static void MapItemEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/items");

        group.MapPost("/todo", async (ItemDto itemDtoS, ApplicationDbContext db, ClaimsPrincipal user) =>
        {
            var userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var item = new TODOItem
            {
                Title = itemDtoS.Title,
                Description = itemDtoS.Description,
                IsCompleted = false,
                UserId = userId
            };

            db.Todos.Add(item);
            await db.SaveChangesAsync();

            return Results.Ok($"Item '{item.Title}' created successfully");
        }).RequireAuthorization();

        group.MapGet("/todo", async (ApplicationDbContext db, ClaimsPrincipal user) =>
        {
            var userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (string.IsNullOrEmpty(userId.ToString())) return Results.BadRequest("User ID not found in token");

            var items = await db.Todos.Where(t => t.UserId == userId).ToListAsync();
            return Results.Ok(items);
        }).RequireAuthorization();

        group.MapPut("/todo/{id}", async (int id, ItemDto itemDto, ApplicationDbContext db, ClaimsPrincipal user) =>
        {
            var userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var item = await db.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (item is null) return Results.NotFound("Item not found");

            item.Title = itemDto.Title;
            item.Description = itemDto.Description;
            await db.SaveChangesAsync();

            return Results.Ok($"Item '{item.Title}' updated successfully");
        }).RequireAuthorization();

        group.MapDelete("/todo/{id}", async (int id, ApplicationDbContext db, ClaimsPrincipal user) =>
        {
            var userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var item = await db.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (item is null) return Results.NotFound("Item not found");

            db.Todos.Remove(item);
            await db.SaveChangesAsync();

            return Results.Ok($"Item '{item.Title}' deleted successfully");
        }).RequireAuthorization();



    }
}