using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adam_s_Notebook_ASP.NET_API.Model
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Path { get; set; }
        [DefaultValue("PNG")]
        public string Format { get; set; }
        [DefaultValue("1024,1024")]
        public string Dimension { get; set; }
        public string? Description { get; set; }
    }
}
