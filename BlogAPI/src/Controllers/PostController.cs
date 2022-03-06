
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

        // [HttpPost]
        // public IActionResult CreatePost([FromBody] PostRegisterDTO post)
        // {
        //     if (!ModelState.IsValid) return BadRequest(ModelState);

        // }

        #endregion Methods
    }
}