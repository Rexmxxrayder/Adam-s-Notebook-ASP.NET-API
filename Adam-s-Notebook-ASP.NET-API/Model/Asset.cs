using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Adam_s_Notebook_ASP.NET_API.Enums;

namespace Adam_s_Notebook_ASP.NET_API.Model
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        public required string Path { get; set; }
        public AssetType Type { get; set; }
        public ICollection<Asset> LinkedAssets { get; set; } = new List<Asset>();
        public required string Format { get; set; }
        public required string Dimension { get; set; }
        public string? Description { get; set; }
    }
}
