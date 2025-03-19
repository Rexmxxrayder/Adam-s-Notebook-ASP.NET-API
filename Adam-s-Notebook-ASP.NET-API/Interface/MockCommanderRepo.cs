using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Interface
{
    public class MockCommanderRepo : IMeshRepo
    {
        public Mesh GetMeshById(int id)
        {
            return new Mesh{Id = 0, Name = "LetterBoss", Format ="GLB", Path = "C://Sharkore//Web//AdamNotebook//Adam-s-Notebook-ASP.NET-API//Adam-s-Notebook-ASP.NET-API//Data//Models3D//LetterBoss//LetterBoss.glb", Textures = [], Dimension = [1,1,1], Description = "Modele de Madame Lettre"};
        }

        public IEnumerable<Mesh> GetMeshes()
        {
            var threeDModels = new List<Mesh>(){
                new Mesh{Id = 0, Name = "LetterBoss", Format ="GLB", Path = "C://Sharkore//Web//AdamNotebook//Adam-s-Notebook-ASP.NET-API//Adam-s-Notebook-ASP.NET-API//Data//Models3D//LetterBoss//LetterBoss.glb", Textures = [], Dimension = [1,1,1], Description = "Modele de Madame Lettre"},
                new Mesh{Id = 0, Name = "Adam", Format ="GLB", Path = "C://Sharkore//Web//AdamNotebook//Adam-s-Notebook-ASP.NET-API//Adam-s-Notebook-ASP.NET-API//Data//Models3D//LetterBoss//LetterBoss.glb", Textures = [], Dimension = [1,1,1], Description = "Modele de Madame Lettre"},
                new Mesh{Id = 0, Name = "Al", Format ="GLB", Path = "C://Sharkore//Web//AdamNotebook//Adam-s-Notebook-ASP.NET-API//Adam-s-Notebook-ASP.NET-API//Data//Models3D//LetterBoss//LetterBoss.glb", Textures = [], Dimension = [1,1,1], Description = "Modele de Madame Lettre"}
            };

            return threeDModels;
        }
    }
}