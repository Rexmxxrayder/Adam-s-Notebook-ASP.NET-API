using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;
using Adam_s_Notebook_ASP.NET_API.Enums;

namespace Adam_s_Notebook_ASP.NET_API.Dtos
{
    public class AssetCreateDto
    {
        [MaxLength(250)]
        public required string Name { get; set; }
        public AssetType Type { get; set; } = AssetType.Mesh;
        public ICollection<Asset> LinkedAssets { get; set; } = new List<Asset>();
        public ICollection<int> LinkedAssetsId { get; set; } = new List<int>();
        public required string Format { get; set; }
        public required string Dimension { get; set; }
        public string? Description { get; set; }
    }
}