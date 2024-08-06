using GradientsApp.Maui.Infrastructure;
using System.Reflection.Metadata;

namespace GradientsApp.Maui.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        //public IAsyncCommand<string> NavigateCommand { get; }

        public HomeViewModel(INavigationService navigationService)
        {
            //NavigateCommand = new AsyncCommand<string>(navigationService.NavigateTo);
        }

        [RelayCommand]
        public async Task GotoFeature(string featureName)
        {
            await Shell.Current.GoToAsync(featureName);
        }
    }
}
