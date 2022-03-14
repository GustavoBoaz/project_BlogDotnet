
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;
using BlogAPI.src.Repositories;
using BlogAPI.src.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region Attributes

        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userServices;

        #endregion Attributes

        #region Constructors
        public UserController(IUserRepository userRepository, IUserServices userServices)
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">UserRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/user
        ///     {
        ///        "name": "Gustavo Boaz",
        ///        "email": "gustavo@email.com",
        ///        "password": "134652"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">Error in request</response>
        /// <response code="401">Exist user email in database</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateUser([FromBody] UserRegisterDTO user)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            return _userServices.CreateUserNotDuplicated(user) == null ? Unauthorized() : Created("", user);
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="404">User not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Get a users by name
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the list users</response>
        /// <response code="204">Users not found</response>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetUsersByName([FromQuery] string name)
        {
            var users = _userRepository.GetUserByName(name);
            if(users.Count < 1) return NoContent();

            return Ok(users);
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">User deleted</response>
        /// <response code="404">User not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return NotFound();

            _userRepository.DeleteUser(id);
            return Ok();
        }

        /// <summary>
        /// Update a user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="user">UserUpdateDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/user/1
        ///     {
        ///        "name": "Gustavo Boaz",
        ///        "password": "134652"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">User updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">User not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateDTO user)
        {
            var userModel = _userRepository.GetUserById(id);
            if(userModel == null) return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            _userRepository.UpdateUser(id, user);
            return Ok();
        }

        #endregion Methods
    }
}