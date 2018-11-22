using Microsoft.EntityFrameworkCore;

namespace webvision.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<UserInfo> userInfos {get; set;}
    }
} 