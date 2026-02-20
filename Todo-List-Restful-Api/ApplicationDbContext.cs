using Microsoft.EntityFrameworkCore;
using TodoList.Entitys;

namespace DBEntityFrameworkCore
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();

        public DbSet<TODOItem> Todos => Set<TODOItem>();

    }
}