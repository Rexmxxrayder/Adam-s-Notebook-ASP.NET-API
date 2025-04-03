using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Data
{
    public interface IAssetRepo
    {
        void CreateAsset(Asset mesh);
        IEnumerable<Asset> GetAssets();
        IEnumerable<Asset> GetAssetsByName(string name);
        Asset? GetAssetById(int id);
        void UpdateAsset(Asset mesh);
        void DeleteAsset(Asset mesh);
        bool SaveChanges();
    }
}
