using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Adam_s_Notebook_ASP.NET_API.Model;
using Adam_s_Notebook_ASP.NET_API.Data;
using AutoMapper;
using Adam_s_Notebook_ASP.NET_API.Dtos;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace Adam_s_Notebook_ASP.NET_API.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IAssetRepo<Image> _repository;
        private readonly IMapper _mapper;

        public ImagesController(IAssetRepo<Image> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImageReadDto>> GetAllImages()
        {
            var imagesItems = _repository.GetAssets();
            return Ok(_mapper.Map<IEnumerable<ImageReadDto>>(imagesItems));
        }

        [HttpGet("{id}", Name = "GetImageById")]
        public ActionResult<ImageReadDto> GetImageById(int id)
        {
            var imageItem = _repository.GetAssetById(id);
            if (imageItem != null)
            {
                return Ok(_mapper.Map<ImageReadDto>(imageItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<ImageReadDto> CreateImage(ImageCreateDto imageCreateDto)
        {
            var imageModel = _mapper.Map<Image>(imageCreateDto);
            _repository.CreateAsset(imageModel);
            _repository.SaveChanges();

            var imageReadDto = _mapper.Map<ImageReadDto>(imageModel);
            return CreatedAtRoute(nameof(GetImageById), new { Id = imageReadDto.Id }, imageReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateImage(int id, ImageUpdateDto imageUpdateDto)
        {
            var imageModelFromRepo = _repository.GetAssetById(id);
            if (imageModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(imageUpdateDto, imageModelFromRepo);

            _repository.UpdateAsset(imageModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialImageUpdate(int id, JsonPatchDocument<ImageUpdateDto> patchDto)
        {
            var imageModelFromRepo = _repository.GetAssetById(id);
            if (imageModelFromRepo == null)
            {
                return NotFound();
            }

            var imageToPatch = _mapper.Map<ImageUpdateDto>(imageModelFromRepo);
            patchDto.ApplyTo(imageToPatch, ModelState);

            if(!TryValidateModel(imageToPatch)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(imageToPatch,imageModelFromRepo);

            _repository.UpdateAsset(imageModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
         public ActionResult DeleteImage(int id)
        {
            var imageModelFromRepo = _repository.GetAssetById(id);
            if (imageModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteAsset(imageModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}