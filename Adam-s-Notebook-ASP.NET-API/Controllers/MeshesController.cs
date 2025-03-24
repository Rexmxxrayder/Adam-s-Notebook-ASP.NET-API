using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;
using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Dtos;

namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/mesh")]
    [ApiController]
    public class MeshesController : ControllerBase
    {
        private readonly IAssetRepo _repository;
        private readonly IMapper _mapper;

        public MeshesController(IAssetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeshReadDto>> GetAllMeshes()
        {
            var meshItems = _repository.GetMeshes();
            return Ok(_mapper.Map<IEnumerable<MeshReadDto>>(meshItems));
        }


        [HttpGet("{id}")]
        public ActionResult<MeshReadDto> GetMeshById(int id)
        {
            var meshItem = _repository.GetMeshById(id);
            if (meshItem != null)
            {
                return Ok(_mapper.Map<MeshReadDto>(meshItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<MeshReadDto> CreateMesh(MeshCreateDto meshCreateDto)
        {
            var meshModel = _mapper.Map<Mesh>(meshCreateDto);
            _repository.CreateMesh(meshModel);
            _repository.SaveChanges();
            return Ok(meshModel);
        }
    }
}