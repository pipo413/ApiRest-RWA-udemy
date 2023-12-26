using CodePulse_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePulse_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Creamos el contructor con opciones
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Creamos las propiedades
        // el tipo DbSet recibe como objeto nuestros modelos de db que son Data/Models/BlogPost.cs y  Data/Models/Category.cs
        public DbSet<BlogPost> BlogPosts{ get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
