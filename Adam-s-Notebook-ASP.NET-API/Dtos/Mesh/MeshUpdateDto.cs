using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Dtos{
    public class MeshUpdateDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        public string Format { get; set; }
        public string Dimension { get; set; }
        public string? Description { get; set; }
    }
}