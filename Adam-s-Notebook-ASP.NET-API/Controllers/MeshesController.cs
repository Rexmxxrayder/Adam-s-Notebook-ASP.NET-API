using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;
using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;


namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/mesh")]
    [ApiController]
    public class MeshesController : ControllerBase
    {
        private readonly IAssetRepo<Mesh> _repository;
        private readonly IMapper _mapper;

        private readonly FilePaths _filePaths;

        public MeshesController(IAssetRepo<Mesh> repository, IMapper mapper, IOptions<FilePaths> filePaths)
        {
            _repository = repository;
            _mapper = mapper;
            _filePaths = filePaths.Value;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeshReadDto>> GetAllMeshes()
        {
            var meshItems = _repository.GetAssets();
            return Ok(_mapper.Map<IEnumerable<MeshReadDto>>(meshItems));
        }

        [HttpGet("{id}", Name = "GetMeshById")]
        public ActionResult<MeshReadDto> GetMeshById(int id)
        {
            var meshItem = _repository.GetAssetById(id);
            if (meshItem != null)
            {
                return Ok(_mapper.Map<MeshReadDto>(meshItem));
            }

            return NotFound();
        }


        [HttpGet("/search")]
        public ActionResult GetMesh([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("'name' paremeter is required");
            }

            var meshes = _repository.GetAssetsByName(name);

            if (meshes == null)
            {
                return NotFound();
            }

            return Ok(meshes);
        }

        [HttpGet("{id}/download", Name = "DownloadMesh")]
        public async Task<ActionResult> DownloadMesh(int id)
        {
            var meshItem = _repository.GetAssetById(id);
            if (meshItem == null)
            {
                return NotFound("Mesh not found.");
            }

            string path = GetAbsolutePath(meshItem.Path);
            if (System.IO.File.Exists(path))
            {
                var fileBytes = await System.IO.File.ReadAllBytesAsync(path);
                return File(fileBytes, meshItem.Format, meshItem.Name + GetExtension(meshItem.Format));
            }
            else
            {
                return NotFound("File not found");
            }
        }

        [HttpPost]
        public ActionResult<MeshReadDto> CreateMesh(MeshCreateDto meshCreateDto)
        {
            var meshModel = _mapper.Map<Mesh>(meshCreateDto);
            _repository.CreateAsset(meshModel);
            _repository.SaveChanges();

            var meshReadDto = _mapper.Map<MeshReadDto>(meshModel);
            return CreatedAtRoute(nameof(GetMeshById), new { Id = meshReadDto.Id }, meshReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMesh(int id, MeshUpdateDto meshUpdateDto)
        {
            var meshModelFromRepo = _repository.GetAssetById(id);
            if (meshModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(meshUpdateDto, meshModelFromRepo);

            _repository.UpdateAsset(meshModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMeshUpdate(int id, JsonPatchDocument<MeshUpdateDto> patchDto)
        {
            var meshModelFromRepo = _repository.GetAssetById(id);
            if (meshModelFromRepo == null)
            {
                return NotFound();
            }

            var meshToPatch = _mapper.Map<MeshUpdateDto>(meshModelFromRepo);
            patchDto.ApplyTo(meshToPatch, ModelState);

            if (!TryValidateModel(meshToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(meshToPatch, meshModelFromRepo);

            _repository.UpdateAsset(meshModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMesh(int id)
        {
            var meshModelFromRepo = _repository.GetAssetById(id);
            if (meshModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteAsset(meshModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        private string GetExtension(string contentType)
        {
            return contentType switch
            {
                "model/gltf-binary" => ".glb",
                "application/x-fbx" => ".fbx",
                _ => "",
            };
        }

        private string GetAbsolutePath(string relativePath)
        {
            return Path.Combine(_filePaths.SrcPath, relativePath.TrimStart('/'));
        }
    }
}