
using BlogAPI.src.DTOs;
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
    public class ThemeController : ControllerBase
    {
        #region Attributes

        private readonly IThemeRepository _themeRepository;

        #endregion Attributes

        #region Constructors

        public ThemeController(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Get all themes
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns all themes</response>
        /// <response code="204">No content</response>
        [HttpGet("all")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllThemes()
        {
            var themes = _themeRepository.GetAllThemes();
            if (themes.Count < 1) return NoContent();

            return Ok(themes);
        }

        /// <summary>
        /// Get theme by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the theme</response>
        /// <response code="404">Theme not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetThemeById([FromRoute] int id)
        {
            var theme = _themeRepository.GetThemeById(id);
            if (theme == null) return NotFound();

            return Ok(theme);
        }

        /// <summary>
        /// Get themes by description
        /// </summary>
        /// <param name="description">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the theme</response>
        /// <response code="204">Theme no content</response>
        [HttpGet("search")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetThemesByDescription([FromQuery] string description)
        {
            var themes = _themeRepository.GetThemeByDescription(description);
            if (themes.Count < 1) return NoContent();

            return Ok(themes);
        }

        /// <summary>
        /// Create a new theme
        /// </summary>
        /// <param name="theme">ThemeRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Theme
        ///     {
        ///        "description": "C#"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created theme</response>
        /// <response code="400">Error in request</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTheme([FromBody] ThemeRegisterDTO theme)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.AddTheme(theme);
            return Created("", theme);
        }

        /// <summary>
        /// Update theme by id
        /// </summary>
        /// <param name="theme">ThemeRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Theme
        ///     {
        ///        "description": "Python"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Theme updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">Theme not found</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTheme([FromBody] ThemeUpdateDTO theme)
        {
            var themeModel = _themeRepository.GetThemeById(theme.Id);
            if (themeModel == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.UpdateTheme(theme);
            return Ok();
        }

        /// <summary>
        /// Delete theme by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Theme deleted</response>
        /// <response code="404">Theme not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTheme([FromRoute] int id)
        {
            var theme = _themeRepository.GetThemeById(id);
            if (theme == null) return NotFound();

            _themeRepository.DeleteTheme(id);
            return Ok();
        }

        #endregion Methods
    }
}