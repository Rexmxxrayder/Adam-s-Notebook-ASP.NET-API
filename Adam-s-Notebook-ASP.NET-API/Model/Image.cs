using System.Data;

namespace Adam_s_Notebook_ASP.NET_API.Model {
    public class Image {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Format { get; set; }
        public float[] Dimension { get; set; }
        public string Description { get; set; }
    }
}
