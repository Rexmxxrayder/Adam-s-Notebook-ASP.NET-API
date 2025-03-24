using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Dtos
{
    public class MeshReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ICollection<Image> Textures { get; set; } = new List<Image>();
        public string Format { get; set; }
        public string Dimension { get; set; }
        public string? Description { get; set; }
    }
}
