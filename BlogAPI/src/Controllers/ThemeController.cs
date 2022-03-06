
using BlogAPI.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public IActionResult CreateTheme([FromBody] ThemeRegisterDTO theme)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.AddTheme(theme);
            return Created("", theme);
        }

        [HttpGet("{id}")]
        public IActionResult GetThemeById([FromRoute] int id)
        {
            var theme = _themeRepository.GetThemeById(id);
            if (theme == null) return NotFound();

            return Ok(theme);
        }

        [HttpGet("search")]
        public IActionResult GetThemesByDescription([FromQuery] string description)
        {
            var themes = _themeRepository.GetThemeByDescription(description);
            if (themes.Count < 1) return NoContent();

            return Ok(themes);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheme([FromRoute] int id)
        {
            var theme = _themeRepository.GetThemeById(id);
            if (theme == null) return NotFound();

            _themeRepository.DeleteTheme(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTheme([FromRoute] int id, [FromBody] ThemeUpdateDTO theme)
        {
            var themeModel = _themeRepository.GetThemeById(id);
            if (themeModel == null) return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            _themeRepository.UpdateTheme(id, theme);
            return Ok();
        }

        #endregion Methods
    }
}