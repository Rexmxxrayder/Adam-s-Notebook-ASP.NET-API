using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Dtos{
    public class AssetUpdateDto
    {
        [MaxLength(250)]
        public required string Name { get; set; }
        public ICollection<int> Textures { get; set; } = new List<int>();
        public required string Format { get; set; }
        public required string Dimension { get; set; }
        public string? Description { get; set; }
    }
}