
using System.Collections.Generic;
using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions themes.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public interface IThemeRepository
    {
        ThemeModel GetThemeById(int id);
        List<ThemeModel> GetThemeByDescription(string description);
        void AddTheme(ThemeRegisterDTO theme);
        void UpdateTheme(int id, ThemeUpdateDTO theme);
        void DeleteTheme(int id);
    }
}