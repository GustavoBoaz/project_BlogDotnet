
using System.Linq;
using System.Collections.Generic;
using BlogAPI.Data;
using BlogAPI.Models;

namespace BlogAPI.Repositories.Implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Theme.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class ThemeRepository : IThemeRepository
    {
        #region Attributes

        private readonly AppBlogContext _context;

        #endregion Attributes

        #region Constructors

        /// <summary>
        /// <para>Resume: Constructor of class.</para>
        /// </summary>
        /// <param name="context">AppBlogContext</param>
        public ThemeRepository(AppBlogContext context)
        {
            _context = context;
        }

        #endregion Constructors

        #region IThemeRepository implementation

        /// <summary>
        /// <para>Resume: method for add a new theme.</para>
        /// </summary>
        /// <param name="theme">ThemeRegisterDTO</param>
        public void AddTheme(ThemeRegisterDTO theme)
        {
            _context.Themes.Add(new ThemeModel
            {
                Description = theme.Description,
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// <para>Resume: method for delete a theme.</para>
        /// </summary>
        /// <param name="id">Id of theme</param>
        public void DeleteTheme(int id)
        {
            _context.Themes.Remove(GetThemeById(id));   
        }

        /// <summary>
        /// <para>Resume: method for get theme by description.</para>
        /// </summary>
        /// <param name="description">Description of theme</param>
        /// <returns>List of ThemeModel</returns>
        public List<ThemeModel> GetThemeByDescription(string description)
        {
            return _context.Themes.Where(x => x.Description.Contains(description)).ToList();
        }

        /// <summary>
        /// <para>Resume: method for get theme by id.</para>
        /// </summary>
        /// <param name="id">Id of theme</param>
        /// <returns>ThemeModel</returns>
        public ThemeModel GetThemeById(int id)
        {
            return _context.Themes.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// <para>Resume: Implement method for update a theme.</para>
        /// </summary>
        /// <param name="theme">ThemeUpdateDTO</param>
        public void UpdateTheme(int id, ThemeUpdateDTO theme)
        {
            var themeUpdate = GetThemeById(id);
            themeUpdate.Description = theme.Description;
            _context.Themes.Update(themeUpdate);
        }

        #endregion IThemeRepository implementation
    }
}