using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Dtos;

namespace Adam_s_Notebook_ASP.NET_API.Profiles{
    public class MeshesProfiles : Profile{
        public MeshesProfiles(){
            CreateMap<Mesh, MeshReadDto>();
            CreateMap<MeshCreateDto, Mesh>();
            CreateMap<MeshUpdateDto, Mesh>();
            CreateMap<Mesh, MeshUpdateDto>();
        }
    }
}