using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Dtos;

namespace Adam_s_Notebook_ASP.NET_API.Profiles{
    public class ImagesProfile : Profile{
        public ImagesProfile(){
            CreateMap<Image, ImageReadDto>();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>();
            CreateMap<Image, ImageUpdateDto>();
        }
    }
}