using Microsoft.EntityFrameworkCore;

namespace Adam_s_Notebook_ASP.NET_API.Model {
    public class ModelContext : DbContext{
        public DbSet<Mesh> Meshes { get; set; }
        public DbSet<Texture> Textures { get; set; }

        public ModelContext(DbContextOptions option) : base(option) {

        }
    }
}
