using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Dtos;

namespace Adam_s_Notebook_ASP.NET_API.Profiles{
    public class AssetsProfiles : Profile{
        public AssetsProfiles(){
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<AssetUpdateDto, Asset>();
            CreateMap<Asset, AssetUpdateDto>();
        }
    }
}