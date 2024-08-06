using GradientsApp.Maui.Infrastructure;
using GradientsApp.Maui.Models;
using MagicGradients;
using GradientsApp.Maui.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GradientsApp.Maui.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INavigationService _navigationService;

        public string Title => "Categories";

        private List<CategoryItem> _categories;
        public List<CategoryItem> Categories
        {
            get => _categories;
            private set => SetProperty(ref _categories, value);
        }

        [ObservableProperty]
        public CategoryItem selectedCategory;

        partial void OnSelectedCategoryChanged(CategoryItem value)
        {
            if (value == null)
                return;

            _navigationService.NavigateTo("Gallery", value);
        }

        public CategoriesViewModel(
            ICategoryRepository categoryRepository, 
            INavigationService navigationService)
        {
            _categoryRepository = categoryRepository;
            _navigationService = navigationService;
        }


        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadCategories(_categoryRepository);
        }

        private void LoadCategories(ICategoryRepository repository)
        {
            Categories = repository.GetCategories().Select(x => new CategoryItem
            {
                Name = x.Name,
                Source = new CssGradientSource(x.Stylesheet),
                Tag = x.Tag
            }).ToList();
        }
    }
}
