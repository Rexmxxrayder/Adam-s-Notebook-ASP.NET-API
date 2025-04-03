using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Enums;

namespace Adam_s_Notebook_ASP.NET_API.Dtos
{
    public class AssetReadDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public AssetType Type { get; set; } = AssetType.Mesh;
        public ICollection<int> LinkedAssets { get; set; } = new List<int>();
        public required string Format { get; set; }
        public required string Dimension { get; set; }
        public string? Description { get; set; }
    }
}
