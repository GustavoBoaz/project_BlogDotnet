
using BlogAPI.src.Models;
using BlogAPI.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns all posts</response>
        /// <response code="204">No content</response>
        [HttpGet("all")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllPosts()
        {
            var posts = _postRepository.GetAllPosts();
            if (posts.Count < 1) return NoContent();

            return Ok(posts);
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the post</response>
        /// <response code="404">Post not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPostById([FromRoute] int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Get posts by title or description theme or name creator
        /// </summary>
        /// <param name="title">string</param>
        /// <param name="descriptionTheme">string</param>
        /// <param name="nameCreator">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the posts</response>
        /// <response code="204">No content</response>
        [HttpGet("search")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetPostsBySearch(
            [FromQuery] string title,
            [FromQuery] string descriptionTheme,
            [FromQuery] string nameCreator)
        {
            var posts = _postRepository.GetPostsBySearch(title, descriptionTheme, nameCreator);
            if (posts.Count < 1) return NoContent();

            return Ok(posts);
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Post
        ///     {
        ///        "title": "C# in 2022",
        ///        "description": "C# in 2022 is the future of programming",
        ///        "photo": "URLPHOTO",
        ///        "descriptionTheme": "C#",
        ///        "emailCreator": "gustavo@domain.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created post</response>
        /// <response code="400">Error in request</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePost([FromBody] PostRegisterDTO post)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _postRepository.AddPost(post) == null ? BadRequest() : Created("", post);
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Post
        ///     {
        ///        "title": "C# in 2022",
        ///        "description": "C# in 2022 is the future of programming",
        ///        "descriptionTheme": "C#",
        ///        "emailUser": "gustavo@email.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated post</response>
        /// <response code="400">Error in request</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePost([FromBody] PostUpdateDTO post)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _postRepository.UpdatePost(post) == null ? BadRequest() : Ok(post);
        }

        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Post deleted</response>
        /// <response code="404">Post not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePost([FromRoute] int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post == null) return NotFound();

            _postRepository.DeletePost(id);
            return Ok();
        }

        #endregion Methods
    }
}