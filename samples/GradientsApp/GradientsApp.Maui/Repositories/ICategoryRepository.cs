using GradientsApp.Maui.Models;
using System.Collections.Generic;

namespace GradientsApp.Maui.Repositories
{
    public interface ICategoryRepository : ICanUpdateMyself
    {
        List<Category> GetCategories();
        List<Theme> GetThemes();
    }
}
