
using BlogAPI.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Attributes

        private readonly IPostRepository _postRepository;

        #endregion Attributes

        #region Constructors

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        public IActionResult CreatePost([FromBody] PostRegisterDTO post)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _postRepository.AddPost(post) == null ? BadRequest() : Created("", post);
        }

        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            var posts = _postRepository.GetAllPosts();
            if (posts.Count < 1) return NoContent();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById([FromRoute] int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpGet("search")]
        public IActionResult GetPostsByTitle([FromQuery] string title)
        {
            var posts = _postRepository.GetPostByTitle(title);
            if (posts.Count < 1) return NoContent();

            return Ok(posts);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromRoute] int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post == null) return NotFound();

            _postRepository.DeletePost(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromRoute] int id, [FromBody] PostRegisterDTO post)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _postRepository.UpdatePost(id, post) == null ? BadRequest() : Ok(post);
        }

        #endregion Methods
    }
}