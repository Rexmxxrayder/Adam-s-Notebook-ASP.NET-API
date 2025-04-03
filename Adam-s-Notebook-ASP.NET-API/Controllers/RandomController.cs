using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;
using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;


namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    public class RandomController : ControllerBase
    {
        private readonly IAssetRepo _repository;
        private readonly IMapper _mapper;
        private readonly FilePaths _filePaths;

        public RandomController(IAssetRepo repository, IMapper mapper, IOptions<FilePaths> filePaths)
        {
            _repository = repository;
            _mapper = mapper;
            _filePaths = filePaths.Value;
        }

        [Route("api/clean")]
        public ActionResult Clean()
        {
            return Ok();
        }

        [Route("/")]
        public ActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}