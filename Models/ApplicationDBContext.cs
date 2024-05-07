using Microsoft.EntityFrameworkCore;

namespace ELibraryManagement.Models
{
    public class ApplicationDBContext: DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ELibraryManagement;Integrated Security=true;TrustServerCertificate=True;");
        }

    }
}
