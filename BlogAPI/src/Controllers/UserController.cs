
using BlogAPI.src.DTOs;
using BlogAPI.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRegisterDTO user)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            _userRepository.AddUser(user);
            return Created("", user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("search")]
        public IActionResult GetUsersByName([FromQuery] string name)
        {
            var users = _userRepository.GetUserByName(name);
            if(users.Count < 1) return NoContent();

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return NotFound();

            _userRepository.DeleteUser(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateDTO user)
        {
            var userModel = _userRepository.GetUserById(id);
            if(userModel == null) return BadRequest(ModelState);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            _userRepository.UpdateUser(id, user);
            return Ok();
        }
    }
}