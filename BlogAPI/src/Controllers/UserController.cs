
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;
using BlogAPI.src.Repositories;
using BlogAPI.src.Services;
using Microsoft.AspNetCore.Authorization;
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
        /// Authenticate user
        /// </summary>
        /// <param name="user">UserLoginDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /auth
        ///     {
        ///        "email": "gustavo@domain.com",
        ///        "password": "134652"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the authorization</response>
        /// <response code="400">Error in request</response>
        /// <response code="401">User unauthorized</response>
        [HttpPut("/auth")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorizationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate([FromBody] UserLoginDTO user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _userServices.GetAuthorization(user);
            if (result == null) return Unauthorized();

            return Ok(result);
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="404">User not found</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,USER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

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
        [Authorize(Roles = "ADMIN,USER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetUsersByName([FromQuery] string name)
        {
            var users = _userRepository.GetUserByName(name);
            if (users.Count < 1) return NoContent();

            return Ok(users);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">UserRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User
        ///     {
        ///        "name": "Gustavo Boaz",
        ///        "email": "gustavo@domain.com",
        ///        "password": "134652",
        ///        "photo": "URLPHOTO",
        ///        "role": "ADMIN"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">Error in request</response>
        /// <response code="401">Exist user email in database</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateUser([FromBody] UserRegisterDTO user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _userServices.CreateUserNotDuplicated(user) == null ? Unauthorized() : Created("", user);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">UserUpdateDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User
        ///     {
        ///        "id": 1,    
        ///        "name": "Gustavo Boaz",
        ///        "password": "134652",
        ///        "photo": "URLPHOTO"
        ///        "role": "ADMIN"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">User updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Authorize(Roles = "ADMIN,USER")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser([FromBody] UserUpdateDTO user)
        {
            var userModel = _userRepository.GetUserById(user.Id);
            if (userModel == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userRepository.UpdateUser(user);
            return Ok();
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">User deleted</response>
        /// <response code="404">User not found</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            _userRepository.DeleteUser(id);
            return Ok();
        }

        #endregion Methods
    }
}