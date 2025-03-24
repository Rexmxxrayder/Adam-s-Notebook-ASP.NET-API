using System.ComponentModel;
using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Dtos{
    public class MeshCreateDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        [DefaultValue("FBX")]
        public string Format { get; set; }
        [DefaultValue("1,1,1")]
        public string Dimension { get; set; }
        public string? Description { get; set; }
    }
}