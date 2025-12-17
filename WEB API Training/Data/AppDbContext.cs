using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_API_Training.Models;


namespace WEB_API_Training.Data
{
    // 1) installare i pachetti
    public class AppDbContext : IdentityDbContext // 2) aggiungere IdentityDbContext => Program
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StudentModel> Students { get; set; }
    }
}