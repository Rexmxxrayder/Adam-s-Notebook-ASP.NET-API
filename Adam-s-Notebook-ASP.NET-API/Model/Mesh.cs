using System.Data;

namespace Adam_s_Notebook_ASP.NET_API.Model {
    public class Mesh {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        public string Format { get; set; }
        public float[] Dimension { get; set; }
        public string Description { get; set; }
    }
}
