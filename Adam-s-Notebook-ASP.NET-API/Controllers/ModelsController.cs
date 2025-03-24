using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;

namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/mesh")]
    [ApiController]
    public class MeshesController : ControllerBase
    {
        private readonly IMeshRepo _repository;
        public MeshesController(IMeshRepo repository){
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mesh>> GetAllMeshes()
        {
            var meshItems = _repository.GetMeshes();
            return Ok(meshItems);
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Mesh>> GetMeshById(int id)
        {
            var meshItem = _repository.GetMeshById(id);
            return Ok(meshItem);
        }
    }
}