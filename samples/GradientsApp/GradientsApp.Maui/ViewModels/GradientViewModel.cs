using GradientsApp.Maui.Infrastructure;
using GradientsApp.Maui.Models;
using MagicGradients;
using System.Windows.Input;

namespace GradientsApp.Maui.ViewModels
{
    public partial class GradientViewModel : BaseViewModel
    {
        private IGradientSource _source;
        public IGradientSource Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        private Dimensions _size;
        public Dimensions Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }
        
        public bool IsSkiaVisible { get; set; } = true;
        public bool IsGraphicsSkiaVisible { get; set; } = true;
        public bool IsGraphicsNativeVisible { get; set; } = true;

        public ICommand ShowTabCommand { get; }

        public GradientViewModel()
        {
            ShowTabCommand = new Command(ShowTab);
        }
        
        public void Prepare(GalleryItem parameter)
        {
            Source = parameter.Source;
            Size = parameter.Size;

            OnPropertyChanged(nameof(Source));
            OnPropertyChanged(nameof(Size));
        }

        private void ShowTab(object parameter)
        {
            IsSkiaVisible = false;
            IsGraphicsSkiaVisible = false;
            IsGraphicsNativeVisible = false;

            var tab = (string)parameter;

            switch (tab)
            {
                case "skia":
                    IsSkiaVisible = true;
                    break;
                case "gskia":
                    IsGraphicsSkiaVisible = true;
                    break;
                case "gnative":
                    IsGraphicsNativeVisible = true;
                    break;
                case "all":
                    IsSkiaVisible = true;
                    IsGraphicsSkiaVisible = true;
                    IsGraphicsNativeVisible = true;
                    break;
            }

            OnPropertyChanged(nameof(IsSkiaVisible));
            OnPropertyChanged(nameof(IsGraphicsSkiaVisible));
            OnPropertyChanged(nameof(IsGraphicsNativeVisible));
        }
    }
}
