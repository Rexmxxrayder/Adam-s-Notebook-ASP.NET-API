using Microsoft.AspNetCore.Mvc;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;
using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;


namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/asset")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepo _repository;
        private readonly IMapper _mapper;
        private readonly FilePaths _filePaths;

        public AssetsController(IAssetRepo repository, IMapper mapper, IOptions<FilePaths> filePaths)
        {
            _repository = repository;
            _mapper = mapper;
            _filePaths = filePaths.Value;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AssetReadDto>> GetAllAssets()
        {
            var meshItems = _repository.GetAssets();
            return Ok(_mapper.Map<IEnumerable<AssetReadDto>>(meshItems));
        }

        [HttpGet("{id}", Name = "GetAssetById")]
        public ActionResult<AssetReadDto> GetAssetById(int id)
        {
            var meshItem = _repository.GetAssetById(id);
            if (meshItem != null)
            {
                return Ok(_mapper.Map<AssetReadDto>(meshItem));
            }

            return NotFound();
        }


        [HttpGet("/search")]
        public ActionResult GetAssetByName([FromQuery] string name)
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

        [HttpGet("{id}/download", Name = "DownloadAsset")]
        public async Task<ActionResult> DownloadAsset(int id)
        {
            var meshItem = _repository.GetAssetById(id);
            if (meshItem == null)
            {
                return NotFound("Asset not found.");
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
        public ActionResult<AssetReadDto> CreateAsset(AssetCreateDto meshCreateDto)
        {
            var meshModel = _mapper.Map<Asset>(meshCreateDto);
            _repository.CreateAsset(meshModel);
            _repository.SaveChanges();

            var meshReadDto = _mapper.Map<AssetReadDto>(meshModel);
            return CreatedAtRoute(nameof(GetAssetById), new { Id = meshReadDto.Id }, meshReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAsset(int id, AssetUpdateDto meshUpdateDto)
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
        public ActionResult PartialAssetUpdate(int id, JsonPatchDocument<AssetUpdateDto> patchDto)
        {
            var meshModelFromRepo = _repository.GetAssetById(id);
            if (meshModelFromRepo == null)
            {
                return NotFound();
            }

            var meshToPatch = _mapper.Map<AssetUpdateDto>(meshModelFromRepo);
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
        public ActionResult DeleteAsset(int id)
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
                "image/png" => ".png",
                "image/jpeg" => ".jpeg",
                _ => "",
            };
        }

        private string GetAbsolutePath(string relativePath)
        {
            if(_filePaths == null || _filePaths.SrcPath == null){
                throw new ArgumentNullException("Src Path Null");
            }

            return Path.Combine(_filePaths.SrcPath, relativePath.TrimStart('/'));
        }
    }
}