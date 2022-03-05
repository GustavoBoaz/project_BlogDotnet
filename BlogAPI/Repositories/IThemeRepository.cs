
using System.Collections.Generic;
using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    public interface IThemeRepository
    {
        ThemeModel GetTheme(int id);
        List<ThemeModel> GetThemeByDescription(string description);
        void AddTheme(ThemeModel theme);
        void UpdateTheme(ThemeModel theme);
        void DeleteTheme(int id);
    }
}