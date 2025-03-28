using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Dtos{
    public class MeshCreateDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        public string Format { get; set; } = "model/gltf-binary";
        public string Dimension { get; set; } = "1,1,1";
        public string? Description { get; set; }
    }
}