using Microsoft.EntityFrameworkCore;
using SudriaGonzalo.Models;

namespace SudriaGonzalo.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) { }
    
        public DbSet<UserModel> Users { get; set; }
    }
}