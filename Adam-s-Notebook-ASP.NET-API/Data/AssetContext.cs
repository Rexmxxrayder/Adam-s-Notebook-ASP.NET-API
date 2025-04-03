using Microsoft.EntityFrameworkCore;
using Adam_s_Notebook_ASP.NET_API.Model; 

namespace Adam_s_Notebook_ASP.NET_API.Data {
    public class AssetContext : DbContext{
        public DbSet<Asset> Assets { get; set; }

        public AssetContext(DbContextOptions option) : base(option) {

        }
    }
}
