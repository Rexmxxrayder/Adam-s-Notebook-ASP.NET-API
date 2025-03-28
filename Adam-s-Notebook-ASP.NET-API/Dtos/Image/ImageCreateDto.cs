using Adam_s_Notebook_ASP.NET_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Dtos{
    public class ImageCreateDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public string Path { get; set; }
        public string Format { get; set; } = "PNG";
        public string Dimension { get; set; } = "1024,1024";
        public string? Description { get; set; }
    }
}