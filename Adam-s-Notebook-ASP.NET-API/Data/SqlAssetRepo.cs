using System;
using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Data;

public class SqlAssetRepo : IAssetRepo
{
    private readonly AssetContext _context;

    public SqlAssetRepo(AssetContext context)
    {
        _context = context;
    }

    public void CreateAsset(Asset asset)
    {
        if (asset == null)
        {
            throw new ArgumentNullException(nameof(asset));
        }

        _context.Assets.Add(asset);
    }

    public IEnumerable<Asset> GetAssets()
    {
        return _context.Assets.ToList();
    }

    public IEnumerable<Asset> GetAssetsByName(string name)
    {
        return _context.Assets.Where(p => p.Name == name).ToList();
    }


    public void UpdateAsset(Asset asset)
    {

    }

    public void DeleteAsset(Asset asset)
    {
        if (asset == null)
        {
            throw new ArgumentNullException(nameof(asset));
        }

        _context.Assets.Remove(asset);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public Asset? GetAssetById(int id)
    {
        Asset? asset = _context.Assets.FirstOrDefault(p => p.Id == id);
        return asset;
    }
}
