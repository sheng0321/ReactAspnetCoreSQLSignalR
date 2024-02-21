using Microsoft.EntityFrameworkCore;

namespace ChatApp.Server.Model
{
    public class AppDbContext:DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Message>  Messages { get; set; }
    }
}
