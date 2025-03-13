using Microsoft.EntityFrameworkCore;

namespace Adam_s_Notebook_ASP.NET_API {
    public class Model3dDb : DbContext{
        public Model3dDb(DbContextOptions<Model3dDb> options) : base(options) { }

        public DbSet<Model3d> Model3ds => Set<Model3d>();
    }
}
