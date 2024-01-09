using Microsoft.AspNetCore.Mvc;
using PinterestReplika_Core.Models.NoSqlEntities;
using PinterestReplika_Repositories.Interfaces;

namespace PinterestReplika_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostMetadataController : ControllerBase
    {
        private readonly IPostMetadataRepository _postMetadataRepository;
        public PostMetadataController(IPostMetadataRepository postMetadataRepository)
        {
            _postMetadataRepository = postMetadataRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostMetadata>>> GetAll() => Ok(await _postMetadataRepository.GetAll());

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<PostMetadata>> GetById(string id)
        {
            var student = await _postMetadataRepository.GetById(id);

            return student is null ? NotFound() : Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostMetadata student)
        {
            var createdMetadataPost = await _postMetadataRepository.Create(student);
            return createdMetadataPost is null
                ? throw new Exception("PostMetadata creation failed")
                : CreatedAtAction(nameof(GetById),
                new { id = createdMetadataPost.Id }, createdMetadataPost);
        }
    }
}
