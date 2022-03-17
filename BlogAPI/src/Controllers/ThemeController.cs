
using BlogAPI.src.Models;
using BlogAPI.src.Repositories;
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
        /// Create a new theme
        /// </summary>
        /// <param name="theme">ThemeRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/theme
        ///     {
        ///        "description": "Gustavo Boaz"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created theme</response>
        /// <response code="400">Error in request</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTheme([FromBody] ThemeRegisterDTO theme)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.AddTheme(theme);
            return Created("", theme);
        }

        /// <summary>
        /// Get theme by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the theme</response>
        /// <response code="404">Theme not found</response>
        [HttpGet("{id}")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThemeModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetThemesByDescription([FromQuery] string description)
        {
            var themes = _themeRepository.GetThemeByDescription(description);
            if (themes.Count < 1) return NoContent();

            return Ok(themes);
        }

        /// <summary>
        /// Delete theme by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Theme deleted</response>
        /// <response code="404">Theme not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTheme([FromRoute] int id)
        {
            var theme = _themeRepository.GetThemeById(id);
            if (theme == null) return NotFound();

            _themeRepository.DeleteTheme(id);
            return Ok();
        }

        /// <summary>
        /// Update theme by id
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="theme">ThemeRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/theme/1
        ///     {
        ///        "description": "Gustavo Boaz"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Theme updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">Theme not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTheme([FromRoute] int id, [FromBody] ThemeUpdateDTO theme)
        {
            var themeModel = _themeRepository.GetThemeById(id);
            if (themeModel == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.UpdateTheme(id, theme);
            return Ok();
        }

        #endregion Methods
    }
}