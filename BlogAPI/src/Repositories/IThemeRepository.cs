
using System.Collections.Generic;
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;

namespace BlogAPI.src.Repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions themes.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public interface IThemeRepository
    {
        List<ThemeModel> GetAllThemes();
        ThemeModel GetThemeById(int id);
        List<ThemeModel> GetThemeByDescription(string description);
        void AddTheme(ThemeRegisterDTO theme);
        void UpdateTheme(ThemeUpdateDTO theme);
        void DeleteTheme(int id);
    }
}