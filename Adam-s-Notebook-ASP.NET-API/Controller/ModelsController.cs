using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/model")]
    [ApiController]
    public class MeshesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Mesh>> GetAllMeshes()
        {
            return null;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mesh>> GetMeshById()
        {
            return null;
        }
    }
}