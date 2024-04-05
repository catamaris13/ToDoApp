using Microsoft.EntityFrameworkCore;
using ToDoIkonAPI.Models;
namespace ToDoIkonAPI.Data

{
    public class AplicatieDbContext:DbContext
    {
        public AplicatieDbContext(DbContextOptions options) : base(options)
        { 
        }
        public DbSet<User> User { get; set; }
        public DbSet<Sarcina> Task { get; set; }
    }
}
