using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Model
{
    public class Mesh
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        [DefaultValue("model/gltf-binary")]
        public string Format { get; set; }
        [DefaultValue("1,1,1")]
        public string Dimension { get; set; }
        public string? Description { get; set; }
    }
}
