using GradientsApp.Maui.Infrastructure;
using GradientsApp.Maui.Models;
using MagicGradients;
using MagicGradients.Converters;
using GradientsApp.Maui.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GradientsApp.Maui.ViewModels
{
    public partial class GalleryViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly DimensionsTypeConverter _dimensionsConverter = new DimensionsTypeConverter();

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public List<GalleryItem> galleryItems;

        [ObservableProperty]
        public GalleryItem selectedItem;

        partial void OnSelectedItemChanged(GalleryItem value)
        {
            if (value == null)
                return;

            _navigationService.NavigateTo("Gradient", value);
        }

        public GalleryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Prepare(CategoryItem parameter)
        {
            Title = parameter.Name;
            LoadGallery(parameter.Tag);
        }

        private void LoadGallery(string tag)
        {
            var repository = new GradientRepository(new DatabaseProvider());

            GalleryItems = repository.GetByTag(tag).Select(x => new GalleryItem
            {
                Source = new CssGradientSource(x.Stylesheet),
                Size = (Dimensions)_dimensionsConverter.ConvertFromInvariantString(x.Size)
            }).ToList();
        }
    }
}
