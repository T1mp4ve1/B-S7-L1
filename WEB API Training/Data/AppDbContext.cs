using Microsoft.EntityFrameworkCore;
using WEB_API_Training.Models;


namespace WEB_API_Training.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StudentModel> Students { get; set; }
    }
}